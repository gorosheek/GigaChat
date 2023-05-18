using Microsoft.AspNetCore.Cors.Infrastructure;

namespace GigaChat.Server.Cors.Policies;

public static class DevCorsPolicy
{
    public const string PolicyName = "WebClientDev";

    public static void AddDevCorsPolicy(this CorsOptions corsOptions)
    {
        corsOptions.AddPolicy(PolicyName, policy => policy.AllowAnyOrigin());
    }
}