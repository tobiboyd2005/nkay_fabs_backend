using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using nkay_fabs_backend.Entities;
using nkay_fabs_backend.Models.Dtos;
using nkay_fabs_backend.Services;
using System.Security.Claims;
using System.Text.Json;

namespace nkay_fabs_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IFabricInfoRepository _fabricRepository;
        private readonly INotificationRepository _notificationRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<OrdersController> _logger;
        private const int maxPageSize = 20;

        public OrdersController(
            IOrderRepository orderRepository,
            IFabricInfoRepository fabricRepository,
            INotificationRepository notificationRepository,
            IMapper mapper,
            ILogger<OrdersController> logger)
        {
            _orderRepository = orderRepository;
            _fabricRepository = fabricRepository;
            _notificationRepository = notificationRepository;
            _mapper = mapper;
            _logger = logger;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrders(int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
                var userRole = User.FindFirstValue(ClaimTypes.Role);

                if (pageSize > maxPageSize)
                    pageSize = maxPageSize;

                IEnumerable<Order> orders;

                if (userRole == "Admin")
                {
                    var (ordersResult, metadata) = await _orderRepository.GetOrdersAsync(null, pageNumber, pageSize);
                    Response.Headers.Append("X-Pagination", JsonSerializer.Serialize(metadata));
                    orders = ordersResult;
                }
                else
                {
                    orders = await _orderRepository.GetOrdersByUserIdAsync(userId);
                }

                var result = _mapper.Map<IEnumerable<OrderDto>>(orders);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Error retrieving orders.");
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [Authorize]
        [HttpGet("{orderId}")]
        public async Task<ActionResult<OrderDto>> GetOrder(int orderId)
        {
            try
            {
                var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
                var userRole = User.FindFirstValue(ClaimTypes.Role);

                var order = await _orderRepository.GetOrderByIdWithItemsAsync(orderId);
                if (order == null)
                {
                    _logger.LogWarning("Order {OrderId} not found.", orderId);
                    return NotFound();
                }

                if (userRole != "Admin" && order.UserId != userId)
                {
                    return Forbid();
                }

                var result = _mapper.Map<OrderDto>(order);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Error retrieving order {OrderId}.", orderId);
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [Authorize(Roles = "User")]
        [HttpPost]
        public async Task<ActionResult<OrderDto>> CreateOrder([FromBody] CreateOrderDto request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (request.Items == null || !request.Items.Any())
                {
                    ModelState.AddModelError("Items", "Order must have at least one item.");
                    return BadRequest(ModelState);
                }

                var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

                var orderItems = new List<OrderItem>();
                decimal totalAmount = 0;

                foreach (var item in request.Items)
                {
                    var fabric = await _fabricRepository.GetFabricAsync(item.FabricId);
                    if (fabric == null)
                    {
                        ModelState.AddModelError("Items", $"Fabric with ID {item.FabricId} not found.");
                        return BadRequest(ModelState);
                    }

                    if (fabric.StockYards < item.Quantity)
                    {
                        ModelState.AddModelError("Items", $"Insufficient stock for {fabric.Name}. Available: {fabric.StockYards} yards.");
                        return BadRequest(ModelState);
                    }

                    var subTotal = fabric.PricePerYard * item.Quantity;
                    totalAmount += subTotal;

                    orderItems.Add(new OrderItem
                    {
                        FabricId = item.FabricId,
                        Quantity = item.Quantity,
                        UnitPrice = fabric.PricePerYard,
                        SubTotal = subTotal
                    });
                }

                var orderNumber = $"NKF-{DateTime.UtcNow:yyyyMMdd}-{Guid.NewGuid().ToString().Substring(0, 8).ToUpper()}";

                var order = new Order
                {
                    UserId = userId,
                    OrderNumber = orderNumber,
                    TotalAmount = totalAmount,
                    Status = OrderStatus.Pending,
                    ShippingAddress = request.ShippingAddress,
                    Notes = request.Notes,
                    OrderItems = orderItems
                };

                await _orderRepository.CreateOrderAsync(order);

                var createdOrder = await _orderRepository.GetOrderByIdWithItemsAsync(order.Id);
                var result = _mapper.Map<OrderDto>(createdOrder);

                var notification = new Notification
                {
                    UserId = userId,
                    Title = "Order Created",
                    Message = $"Your order #{orderNumber} has been created successfully and is pending confirmation.",
                    Type = NotificationType.Order
                };
                await _notificationRepository.CreateNotificationAsync(notification);

                return CreatedAtAction(nameof(GetOrder), new { orderId = order.Id }, result);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Error creating order.");
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [Authorize(Roles = "User")]
        [HttpPut("{orderId}/cancel")]
        public async Task<IActionResult> CancelOrder(int orderId)
        {
            try
            {
                var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

                var order = await _orderRepository.GetOrderByIdAsync(orderId);
                if (order == null)
                {
                    _logger.LogWarning("Order {OrderId} not found.", orderId);
                    return NotFound();
                }

                if (order.UserId != userId)
                    return Forbid();

                if (order.Status != OrderStatus.Pending)
                {
                    return BadRequest($"Cannot cancel order with status: {order.Status}");
                }

                order.Status = OrderStatus.Cancelled;
                await _orderRepository.SaveChangesAsync();

                var notification = new Notification
                {
                    UserId = userId,
                    Title = "Order Cancelled",
                    Message = $"Your order #{order.OrderNumber} has been cancelled.",
                    Type = NotificationType.Order
                };
                await _notificationRepository.CreateNotificationAsync(notification);

                return Ok(new { message = "Order cancelled successfully." });
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Error cancelling order {OrderId}.", orderId);
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{orderId}/status")]
        public async Task<IActionResult> UpdateOrderStatus(int orderId, [FromBody] UpdateOrderStatusDto request)
        {
            try
            {
                var order = await _orderRepository.GetOrderByIdAsync(orderId);
                if (order == null)
                {
                    _logger.LogWarning("Order {OrderId} not found.", orderId);
                    return NotFound();
                }

                if (!Enum.TryParse<OrderStatus>(request.Status, true, out var newStatus))
                {
                    ModelState.AddModelError("Status", "Invalid status value.");
                    return BadRequest(ModelState);
                }

                var oldStatus = order.Status;
                order.Status = newStatus;
                await _orderRepository.SaveChangesAsync();

                var notification = new Notification
                {
                    UserId = order.UserId,
                    Title = "Order Status Updated",
                    Message = $"Your order #{order.OrderNumber} status has been updated from {oldStatus} to {newStatus}.",
                    Type = NotificationType.Order
                };
                await _notificationRepository.CreateNotificationAsync(notification);

                return Ok(new { message = "Order status updated successfully." });
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Error updating order status for {OrderId}.", orderId);
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }
}