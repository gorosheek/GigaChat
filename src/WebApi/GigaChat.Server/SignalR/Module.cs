using GigaChat.Contracts.Common.Routes;
using GigaChat.Server.SignalR.Hubs;

namespace GigaChat.Server.SignalR;

public static class Module
{
    public static IServiceCollection AddGigaChatSignalR(this IServiceCollection services)
    {
        services.AddSignalR();
        return services;
    }

    public static void MapHubs(this IEndpointRouteBuilder app)
    {
        app.MapHub<ChatHub>(ServerRoutes.Hubs.ChatHub);
    }
}