using System.Linq.Expressions;

using GigaChat.Core.Entities.ChatRooms;

using LinqSpecs;

namespace GigaChat.Core.Common.Specifications.ChatRooms;

public class NotDeletedChatRoomsSpec : Specification<ChatRoom>
{
    public override Expression<Func<ChatRoom, bool>> ToExpression()
    {
        return chatRoom => !chatRoom.IsDeleted;
    }
}