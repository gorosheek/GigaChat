using GigaChat.Core.Common.Repositories.Interfaces;
using GigaChat.Core.Common.Services.Interfaces;
using GigaChat.Core.Entities.ChatRooms;
using GigaChat.Data.Repositories.Common.Base;

namespace GigaChat.Data.Repositories;

public class ChatRoomRepository : RepositoryBase<ChatRoom, long>, IChatRoomRepository
{
    public ChatRoomRepository(
        GigaChatDbContext context,
        IDateTimeProvider dateTimeProvider)
        : base(context, dateTimeProvider)
    {
    }
}