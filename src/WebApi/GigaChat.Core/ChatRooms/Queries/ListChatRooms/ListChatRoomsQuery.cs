using ErrorOr;

using GigaChat.Core.Entities.ChatRooms;

using MediatR;

namespace GigaChat.Core.ChatRooms.Queries.ListChatRooms;

public record ListChatRoomsQuery : IRequest<ErrorOr<IEnumerable<ChatRoom>>>;