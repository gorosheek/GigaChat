using HealthChecks.UI.Client;

using Microsoft.AspNetCore.Diagnostics.HealthChecks;

namespace GigaChat.Server.HealthChecking;

public static class HealthCheckingConfig
{
    public static HealthCheckOptions Options { get; } = new HealthCheckOptions()
    {
        AllowCachingResponses = false,
        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
    };
}