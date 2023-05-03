using ErrorOr;

using GigaChat.Core.Common.Repositories.Interfaces;
using GigaChat.Core.Common.Specifications.ChatRooms;
using GigaChat.Core.Entities.ChatRooms;

using MediatR;

namespace GigaChat.Core.ChatRooms.Queries.ListChatRooms;

public class ListChatRoomsQueryHandler : IRequestHandler<ListChatRoomsQuery, ErrorOr<IEnumerable<ChatRoom>>>
{
    private readonly IChatRoomRepository _chatRoomRepository;

    public ListChatRoomsQueryHandler(IChatRoomRepository chatRoomRepository)
    {
        _chatRoomRepository = chatRoomRepository;
    }

    public async Task<ErrorOr<IEnumerable<ChatRoom>>> Handle(ListChatRoomsQuery request, CancellationToken cancellationToken)
    {
        var spec = new NotDeletedChatRoomsSpec();
        return await _chatRoomRepository.FindMany(spec)
            .ToListAsync(cancellationToken);
    }
}