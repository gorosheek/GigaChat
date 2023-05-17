using GigaChat.Core.Common.Repositories.Common.Interfaces;
using GigaChat.Core.Entities.Users;

namespace GigaChat.Core.Common.Repositories.Interfaces;

public interface IUserRepository : IRepository<User, Guid>
{
    
}