using nkay_fabs_backend.Entities;

namespace nkay_fabs_backend.Services
{
    public interface IMessageRepository
    {
        Task<Conversation?> GetConversationByIdAsync(int conversationId);
        Task<Conversation?> GetConversationByUserIdAsync(int userId);
        Task<IEnumerable<Conversation>> GetUserConversationsAsync(int userId);
        Task<IEnumerable<Conversation>> GetAdminConversationsAsync();
        Task<Conversation> CreateConversationAsync(Conversation conversation);
        Task<Message> CreateMessageAsync(Message message);
        Task<IEnumerable<Message>> GetMessagesByConversationIdAsync(int conversationId);
        Task MarkMessagesAsReadAsync(int conversationId, int userId);
        Task<bool> SaveChangesAsync();
    }
}