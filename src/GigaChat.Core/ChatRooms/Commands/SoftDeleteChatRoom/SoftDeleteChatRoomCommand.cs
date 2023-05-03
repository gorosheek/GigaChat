using ErrorOr;

using MediatR;

namespace GigaChat.Core.ChatRooms.Commands.SoftDeleteChatRoom;

public record SoftDeleteChatRoomCommand(long ChatRoomId)
    : IRequest<ErrorOr<Deleted>>;