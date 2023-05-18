using GigaChat.Core.Common.Repositories.Interfaces;
using GigaChat.Core.Common.Services.Interfaces;
using GigaChat.Core.Common.Entities.Users;
using GigaChat.Data.Repositories.Common.Base;

namespace GigaChat.Data.Repositories;

public class UserRepository : RepositoryBase<User, Guid>, IUserRepository
{
    public UserRepository(
        GigaChatDbContext context,
        IDateTimeProvider dateTimeProvider)
        : base(context, dateTimeProvider)
    {
    }
}