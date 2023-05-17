using GigaChat.Server.SignalR.Hubs;

namespace GigaChat.Server.SignalR;

public static class Module
{
    public static IServiceCollection AddGigaChatSignalR(this IServiceCollection services)
    {
        var builder = services.AddSignalR();
        return services;
    }

    public static void MapHubs(this IEndpointRouteBuilder app)
    {
        app.MapHub<ChatHub>(ChatHub.ConnectionId);
    }
}