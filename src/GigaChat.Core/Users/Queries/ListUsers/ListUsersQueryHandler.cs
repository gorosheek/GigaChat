using ErrorOr;

using GigaChat.Core.Common.Repositories.Interfaces;
using GigaChat.Core.Common.Specifications.Users;
using GigaChat.Core.Entities.Users;

using MediatR;

namespace GigaChat.Core.Users.Queries.ListUsers;

public class ListUsersQueryHandler : IRequestHandler<ListUsersQuery, ErrorOr<IEnumerable<User>>>
{
    private readonly IUserRepository _userRepository;

    public ListUsersQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<IEnumerable<User>>> Handle(
        ListUsersQuery request,
        CancellationToken cancellationToken)
    {
        var spec = new NotDeletedUsersSpec();
        var users = _userRepository.FindMany(spec);
        return await users.ToListAsync(cancellationToken);
    }
}