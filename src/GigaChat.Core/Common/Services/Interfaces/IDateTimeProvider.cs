namespace GigaChat.Core.Common.Services.Interfaces;

public interface IDateTimeProvider
{
    Task<DateTimeOffset> GetUtcNowAsync();
}