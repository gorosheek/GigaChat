using ErrorOr;

using MediatR;

namespace GigaChat.Core.ChatRooms.Commands.CreateChatRoom;

public record CreateChatRoomCommand(string Title, ICollection<Guid> UserIds)
    : IRequest<ErrorOr<Created>>;