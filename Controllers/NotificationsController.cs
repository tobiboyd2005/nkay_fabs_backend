using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using nkay_fabs_backend.Models.Dtos;
using nkay_fabs_backend.Services;
using System.Security.Claims;
using System.Text.Json;

namespace nkay_fabs_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<NotificationsController> _logger;

        public NotificationsController(
            INotificationRepository notificationRepository,
            IMapper mapper,
            ILogger<NotificationsController> logger)
        {
            _notificationRepository = notificationRepository;
            _mapper = mapper;
            _logger = logger;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NotificationDto>>> GetNotifications()
        {
            try
            {
                var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
                var notifications = await _notificationRepository.GetNotificationsByUserIdAsync(userId);
                var result = _mapper.Map<IEnumerable<NotificationDto>>(notifications);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Error retrieving notifications.");
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [Authorize]
        [HttpGet("unread-count")]
        public async Task<ActionResult<object>> GetUnreadCount()
        {
            try
            {
                var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
                var count = await _notificationRepository.GetUnreadCountAsync(userId);
                return Ok(new { unreadCount = count });
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Error getting unread count.");
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [Authorize]
        [HttpPut("mark-read")]
        public async Task<IActionResult> MarkAsRead([FromBody] MarkReadDto request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
                await _notificationRepository.MarkAsReadAsync(request.NotificationIds, userId);
                return Ok(new { message = "Notifications marked as read." });
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Error marking notifications as read.");
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [Authorize]
        [HttpDelete("{notificationId}")]
        public async Task<IActionResult> DeleteNotification(int notificationId)
        {
            try
            {
                var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
                var notifications = await _notificationRepository.GetNotificationsByUserIdAsync(userId);
                var notification = notifications.FirstOrDefault(n => n.Id == notificationId);

                if (notification == null)
                {
                    _logger.LogWarning("Notification {NotificationId} not found.", notificationId);
                    return NotFound();
                }

                notification.IsRead = true;
                await _notificationRepository.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Error deleting notification {NotificationId}.", notificationId);
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }
}