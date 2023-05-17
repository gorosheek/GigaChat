namespace GigaChat.Server.Swagger.Settings;

public sealed class SwaggerGenSettings
{
    public const string SectionName = "SwaggerGen";
    public required string Title { get; init; }
    public required string Description { get; init; }
    public required ContactSettings Contact { get; init; }

    public sealed class ContactSettings
    {
        public required string Name { get; init; }
        public required string Email { get; init; }
        public required Uri Url { get; init; }
    }
}