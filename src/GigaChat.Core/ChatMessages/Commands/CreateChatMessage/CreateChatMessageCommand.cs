using ErrorOr;

using MediatR;

namespace GigaChat.Core.ChatMessages.Commands.CreateChatMessage;

public record CreateChatMessageCommand(string Text, long ChatRoomId, Guid UserId)
    : IRequest<ErrorOr<Created>>;