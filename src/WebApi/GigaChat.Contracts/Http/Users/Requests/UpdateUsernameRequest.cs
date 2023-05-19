namespace GigaChat.Contracts.Http.Users.Requests;

public record UpdateUsernameRequest(Guid UserId, string Name);