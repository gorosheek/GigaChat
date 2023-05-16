namespace GigaChat.Contracts.Authentication.Requests;

public record RegistrationRequest(string Name, string Login, string Password);