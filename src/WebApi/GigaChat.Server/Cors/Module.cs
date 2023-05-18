using GigaChat.Server.Cors.Policies;

namespace GigaChat.Server.Cors;

public static class Module
{
    public static IServiceCollection AddGigaChatCors(
        this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddDevCorsPolicy();
        });

        return services;
    }

    public static void UseGigaChatCors(this IApplicationBuilder app, IHostEnvironment environment)
    {
        if (environment.IsDevelopment())
        {
            app.UseCors(DevCorsPolicy.PolicyName);
        }
    }
}