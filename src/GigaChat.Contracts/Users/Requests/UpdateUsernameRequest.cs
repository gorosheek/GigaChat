namespace GigaChat.Contracts.Users.Requests;

public record UpdateUsernameRequest(Guid UserId, string Name);