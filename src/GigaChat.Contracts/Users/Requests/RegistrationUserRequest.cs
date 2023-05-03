namespace GigaChat.Contracts.Users.Requests;

public record RegistrationUserRequest(string Name, string Login, string Password);