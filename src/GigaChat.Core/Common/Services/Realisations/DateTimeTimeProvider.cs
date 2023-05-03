using GigaChat.Core.Common.Services.Interfaces;

namespace GigaChat.Core.Common.Services.Realisations;

public class DateTimeTimeProvider : IDateTimeProvider
{
    public Task<DateTimeOffset> GetUtcNowAsync()
    {
        return Task.FromResult(DateTimeOffset.UtcNow);
    }
}