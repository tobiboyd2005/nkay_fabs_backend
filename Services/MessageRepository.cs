using Microsoft.EntityFrameworkCore;
using nkay_fabs_backend.Entities;

namespace nkay_fabs_backend.Services
{
    public class MessageRepository : IMessageRepository
    {
        private readonly FabricsDbContext _context;

        public MessageRepository(FabricsDbContext context)
        {
            _context = context;
        }

        public async Task<Conversation?> GetConversationByIdAsync(int conversationId)
        {
            return await _context.Conversations
                .Include(c => c.User)
                .Include(c => c.Admin)
                .FirstOrDefaultAsync(c => c.Id == conversationId);
        }

        public async Task<Conversation?> GetConversationByUserIdAsync(int userId)
        {
            return await _context.Conversations
                .Include(c => c.User)
                .Include(c => c.Admin)
                .FirstOrDefaultAsync(c => c.UserId == userId);
        }

        public async Task<IEnumerable<Conversation>> GetUserConversationsAsync(int userId)
        {
            return await _context.Conversations
                .Include(c => c.User)
                .Include(c => c.Admin)
                .Where(c => c.UserId == userId)
                .OrderByDescending(c => c.LastMessageAt)
                .ToListAsync();
        }

        public async Task<IEnumerable<Conversation>> GetAdminConversationsAsync()
        {
            return await _context.Conversations
                .Include(c => c.User)
                .Include(c => c.Admin)
                .OrderByDescending(c => c.LastMessageAt)
                .ToListAsync();
        }

        public async Task<Conversation> CreateConversationAsync(Conversation conversation)
        {
            _context.Conversations.Add(conversation);
            await _context.SaveChangesAsync();
            return conversation;
        }

        public async Task<Message> CreateMessageAsync(Message message)
        {
            _context.Messages.Add(message);
            
            var conversation = await _context.Conversations.FindAsync(message.ConversationId);
            if (conversation != null)
            {
                conversation.LastMessageAt = message.CreatedAt;
            }

            await _context.SaveChangesAsync();
            return message;
        }

        public async Task<IEnumerable<Message>> GetMessagesByConversationIdAsync(int conversationId)
        {
            return await _context.Messages
                .Include(m => m.Sender)
                .Where(m => m.ConversationId == conversationId)
                .OrderBy(m => m.CreatedAt)
                .ToListAsync();
        }

        public async Task MarkMessagesAsReadAsync(int conversationId, int userId)
        {
            var messages = await _context.Messages
                .Where(m => m.ConversationId == conversationId && m.SenderId != userId && !m.IsRead)
                .ToListAsync();

            foreach (var message in messages)
            {
                message.IsRead = true;
            }

            await _context.SaveChangesAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) >= 0;
        }
    }
}