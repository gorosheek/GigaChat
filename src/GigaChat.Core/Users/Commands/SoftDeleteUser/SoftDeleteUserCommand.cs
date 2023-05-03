using ErrorOr;

using MediatR;

namespace GigaChat.Core.Users.Commands.SoftDeleteUser;

public record SoftDeleteUserCommand(Guid UserId) : IRequest<ErrorOr<Deleted>>;