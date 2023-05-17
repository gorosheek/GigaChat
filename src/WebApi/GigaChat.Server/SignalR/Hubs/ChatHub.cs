using Microsoft.AspNetCore.SignalR;

namespace GigaChat.Server.SignalR.Hubs;

public class ChatHub : Hub
{
    public const string ConnectionId = "chat";

}