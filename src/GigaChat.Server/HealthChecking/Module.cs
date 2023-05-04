using GigaChat.Data;
using GigaChat.Server.HealthChecking.Checks;

namespace GigaChat.Server.HealthChecking;

public static class Module
{
    public static IServiceCollection AddHealthChecking(this IServiceCollection services)
    {
        services.AddHealthChecks()
            .AddCheck<SimpleHealthCheck>(SimpleHealthCheck.Name)
            .AddDbContextCheck<GigaChatDbContext>(); ;
        return services;
    }
}