using GigaChat.Server.Cors.Policies;

namespace GigaChat.Server.Cors;

public static class Module
{
    public static IServiceCollection AddGigaChatCors(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddCors(options =>
        {
            options.AddDevPolicy();
        });

        return services;
    }
}