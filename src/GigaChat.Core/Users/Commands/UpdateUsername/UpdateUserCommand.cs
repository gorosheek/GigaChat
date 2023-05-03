using ErrorOr;

using MediatR;

namespace GigaChat.Core.Users.Commands.UpdateUsername;

public record UpdateUsernameCommand(Guid UserId, string Name) : IRequest<ErrorOr<Updated>>;