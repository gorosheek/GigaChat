using GigaChat.Core.Entities.Base;
using GigaChat.Core.Entities.Users;

namespace GigaChat.Core.Entities.ChatMessages;

public class ChatMessage : EntityBase<long>
{
    private ChatMessage()
    {
        Text = null!;
    }
    
    public ChatMessage(string text, long chatRoomId, Guid userId)
    {
        Text = text;
        ChatRoomId = chatRoomId;
        UserId = userId;
    }
    
    public string Text { get; set; }
    public long ChatRoomId { get; set; }
    public Guid UserId { get; set; }
}