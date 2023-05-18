using GigaChat.Server.Cors.Policies;

namespace GigaChat.Server.Cors;

public static class Module
{
    public static IServiceCollection AddGigaChatCors(
        this IServiceCollection services,
        IConfiguration configuration,
        IHostEnvironment environment)
    {
        services.AddCors(options =>
        {
            if (environment.IsDevelopment())
            {
                options.AddDevPolicy();
            }
        });

        return services;
    }
}