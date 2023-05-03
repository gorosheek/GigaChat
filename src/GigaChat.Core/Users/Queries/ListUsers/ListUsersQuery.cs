using ErrorOr;

using GigaChat.Core.Entities.Users;

using MediatR;

namespace GigaChat.Core.Users.Queries.ListUsers;

public record ListUsersQuery : IRequest<ErrorOr<IEnumerable<User>>>;