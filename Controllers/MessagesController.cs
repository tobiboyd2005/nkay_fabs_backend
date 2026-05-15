using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nkay_fabs_backend.Entities;
using nkay_fabs_backend.Models.Dtos;
using nkay_fabs_backend.Services;
using System.Security.Claims;

namespace nkay_fabs_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IUserRepository _userRepository;
        private readonly INotificationRepository _notificationRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<MessagesController> _logger;

        public MessagesController(
            IMessageRepository messageRepository,
            IUserRepository userRepository,
            INotificationRepository notificationRepository,
            IMapper mapper,
            ILogger<MessagesController> logger)
        {
            _messageRepository = messageRepository;
            _userRepository = userRepository;
            _notificationRepository = notificationRepository;
            _mapper = mapper;
            _logger = logger;
        }

        [Authorize]
        [HttpGet("conversations")]
        public async Task<ActionResult<IEnumerable<ConversationDto>>> GetConversations()
        {
            try
            {
                var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
                var userRole = User.FindFirstValue(ClaimTypes.Role);

                IEnumerable<Conversation> conversations;

                if (userRole == "Admin")
                {
                    conversations = await _messageRepository.GetAdminConversationsAsync();
                }
                else
                {
                    conversations = await _messageRepository.GetUserConversationsAsync(userId);
                }

                var result = new List<ConversationDto>();
                foreach (var conv in conversations)
                {
                    var dto = _mapper.Map<ConversationDto>(conv);
                    var messages = await _messageRepository.GetMessagesByConversationIdAsync(conv.Id);
                    dto.LastMessage = messages.LastOrDefault()?.Content;
                    dto.UnreadCount = messages.Count(m => !m.IsRead && m.SenderId != userId);
                    result.Add(dto);
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Error retrieving conversations.");
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [Authorize]
        [HttpGet("{conversationId}")]
        public async Task<ActionResult<IEnumerable<MessageDto>>> GetMessages(int conversationId)
        {
            try
            {
                var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
                var userRole = User.FindFirstValue(ClaimTypes.Role);

                var conversation = await _messageRepository.GetConversationByIdAsync(conversationId);
                if (conversation == null)
                {
                    _logger.LogWarning("Conversation {ConversationId} not found.", conversationId);
                    return NotFound();
                }

                if (userRole != "Admin" && conversation.UserId != userId)
                    return Forbid();

                await _messageRepository.MarkMessagesAsReadAsync(conversationId, userId);

                var messages = await _messageRepository.GetMessagesByConversationIdAsync(conversationId);
                var result = _mapper.Map<IEnumerable<MessageDto>>(messages);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Error retrieving messages for conversation {ConversationId}.", conversationId);
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [Authorize(Roles = "User")]
        [HttpPost]
        public async Task<ActionResult<MessageDto>> SendMessage([FromBody] CreateMessageDto request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

                var admin = await _userRepository.GetAdminAsync();
                if (admin == null)
                {
                    _logger.LogWarning("No admin found for messaging.");
                    return StatusCode(500, "No admin available for messaging.");
                }

                var conversation = await _messageRepository.GetConversationByUserIdAsync(userId);
                if (conversation == null)
                {
                    conversation = new Conversation
                    {
                        UserId = userId,
                        AdminId = admin.Id
                    };
                    conversation = await _messageRepository.CreateConversationAsync(conversation);
                }

                var message = new Message
                {
                    ConversationId = conversation.Id,
                    SenderId = userId,
                    Content = request.Content,
                    IsRead = false
                };

                message = await _messageRepository.CreateMessageAsync(message);

                var notification = new Notification
                {
                    UserId = admin.Id,
                    Title = "New Message",
                    Message = $"You have a new message from a user.",
                    Type = NotificationType.Message
                };
                await _notificationRepository.CreateNotificationAsync(notification);

                var result = _mapper.Map<MessageDto>(message);
                return CreatedAtAction(nameof(GetMessages), new { conversationId = conversation.Id }, result);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Error sending message.");
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("{conversationId}/reply")]
        public async Task<ActionResult<MessageDto>> ReplyToConversation(int conversationId, [FromBody] CreateMessageDto request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var adminId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

                var conversation = await _messageRepository.GetConversationByIdAsync(conversationId);
                if (conversation == null)
                {
                    _logger.LogWarning("Conversation {ConversationId} not found.", conversationId);
                    return NotFound();
                }

                var message = new Message
                {
                    ConversationId = conversationId,
                    SenderId = adminId,
                    Content = request.Content,
                    IsRead = false
                };

                message = await _messageRepository.CreateMessageAsync(message);

                var notification = new Notification
                {
                    UserId = conversation.UserId,
                    Title = "New Reply",
                    Message = $"You have a new reply from admin.",
                    Type = NotificationType.Message
                };
                await _notificationRepository.CreateNotificationAsync(notification);

                var result = _mapper.Map<MessageDto>(message);
                return CreatedAtAction(nameof(GetMessages), new { conversationId = conversationId }, result);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Error replying to conversation {ConversationId}.", conversationId);
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [Authorize]
        [HttpPut("{conversationId}/read")]
        public async Task<IActionResult> MarkMessagesAsRead(int conversationId)
        {
            try
            {
                var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

                var conversation = await _messageRepository.GetConversationByIdAsync(conversationId);
                if (conversation == null)
                {
                    _logger.LogWarning("Conversation {ConversationId} not found.", conversationId);
                    return NotFound();
                }

                if (conversation.UserId != userId && !User.IsInRole("Admin"))
                    return Forbid();

                await _messageRepository.MarkMessagesAsReadAsync(conversationId, userId);
                return Ok(new { message = "Messages marked as read." });
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Error marking messages as read for conversation {ConversationId}.", conversationId);
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }
}