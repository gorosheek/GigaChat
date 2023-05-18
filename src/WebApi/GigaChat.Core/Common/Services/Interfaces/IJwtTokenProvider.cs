using GigaChat.Core.Common.Entities.Users;

namespace GigaChat.Core.Common.Services.Interfaces;

public interface IJwtTokenProvider
{
    Task<string> GenerateTokenAsync(User user, CancellationToken cancellationToken = default);
    Task<bool> IsExpiredAsync(string token, CancellationToken cancellationToken = default);
}