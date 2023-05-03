namespace GigaChat.Contracts.Common.Routes;

public static class ServerRoutes
{
    public const string Prefix = "/api";
    
    public static class Controllers
    {
        public const string UserController = $"{Prefix}/users";
        public const string ChatMessageController = $"{Prefix}/messages";
        public const string ChatRoomController = $"{Prefix}/rooms";
    }
}