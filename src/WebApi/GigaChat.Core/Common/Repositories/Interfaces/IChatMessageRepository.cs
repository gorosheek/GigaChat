using GigaChat.Core.Common.Repositories.Common.Interfaces;
using GigaChat.Core.Entities.ChatMessages;

namespace GigaChat.Core.Common.Repositories.Interfaces;

public interface IChatMessageRepository : IRepository<ChatMessage, long>
{
    
}