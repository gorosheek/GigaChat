using System.Linq.Expressions;

using GigaChat.Core.Common.Entities.ChatMessages;

using LinqSpecs;

namespace GigaChat.Core.Common.Specifications.ChatMessages;

public class ChatMessagesByChatRoomIdSpec : Specification<ChatMessage>
{
    private readonly long _chatRoomId;

    public ChatMessagesByChatRoomIdSpec(long chatRoomId)
    {
        _chatRoomId = chatRoomId;
    }

    public override Expression<Func<ChatMessage, bool>> ToExpression()
    {
        return x => x.ChatRoomId == _chatRoomId;
    }
}