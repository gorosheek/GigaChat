using ErrorOr;

using GigaChat.Core.Common.Repositories.Interfaces;
using GigaChat.Core.Common.Specifications.ChatMessages;
using GigaChat.Core.Entities.ChatMessages;

using MediatR;

namespace GigaChat.Core.ChatMessages.Queries.ListChatMessages;

public class ListChatMessagesQueryHandler : IRequestHandler<ListChatMessagesQuery, ErrorOr<IEnumerable<ChatMessage>>>
{
    private readonly IChatMessageRepository _chatMessageRepository;

    public ListChatMessagesQueryHandler(IChatMessageRepository chatMessageRepository)
    {
        _chatMessageRepository = chatMessageRepository;
    }

    public async Task<ErrorOr<IEnumerable<ChatMessage>>> Handle(
        ListChatMessagesQuery request,
        CancellationToken cancellationToken)
    {
        var spec = new ChatMessagesByChatRoomIdSpec(request.ChatRoomId);
        return await _chatMessageRepository.FindMany(spec).ToListAsync(cancellationToken);
    }
}