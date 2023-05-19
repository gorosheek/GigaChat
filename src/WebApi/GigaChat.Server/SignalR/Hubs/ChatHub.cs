using GigaChat.Contracts.Common.Routes;

using Microsoft.AspNetCore.SignalR;

using SignalRSwaggerGen.Attributes;

namespace GigaChat.Server.SignalR.Hubs;

[SignalRHub(ServerRoutes.Hubs.ChatHub)]
public class ChatHub : Hub
{
    [HubMethodName("ReceiveMessage")]
    public void Send(string message)
    {
        Clients.All.SendAsync("ReceiveMessage", message);
    }
}