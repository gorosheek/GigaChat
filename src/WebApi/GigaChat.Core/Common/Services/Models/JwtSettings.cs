namespace GigaChat.Core.Common.Services.Models;

public class JwtSettings
{
    public const string SectionName = nameof(JwtSettings);
    public required string Issuer { get; init; }
    public required string Audience { get; init; }
    public required string Secret { get; init; }
    public required int ExpiryMinutes { get; init; }
}