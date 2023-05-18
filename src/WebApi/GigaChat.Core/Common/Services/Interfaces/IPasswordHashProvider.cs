using GigaChat.Core.Common.Entities.Users;

namespace GigaChat.Core.Common.Services.Interfaces;

public interface IPasswordHashProvider
{
    HashedPassword GetHash(string password, byte[] salt);
    HashedPassword GetHash(string password);
}