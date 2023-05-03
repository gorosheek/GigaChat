using ErrorOr;

using MediatR;

namespace GigaChat.Core.ChatRooms.Commands.UpdateChatRoomTitle;

public record UpdateChatRoomTitleCommand(long ChatRoomId, string Title)
    : IRequest<ErrorOr<Updated>>;