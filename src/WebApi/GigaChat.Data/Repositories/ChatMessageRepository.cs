using GigaChat.Core.Common.Repositories.Interfaces;
using GigaChat.Core.Common.Services.Interfaces;
using GigaChat.Core.Common.Entities.ChatMessages;
using GigaChat.Data.Repositories.Common.Base;

namespace GigaChat.Data.Repositories;

public class ChatMessageRepository : RepositoryBase<ChatMessage, long>, IChatMessageRepository
{
    public ChatMessageRepository(
        GigaChatDbContext context,
        IDateTimeProvider dateTimeProvider)
        : base(context, dateTimeProvider)
    {
    }
}