namespace GigaChat.Contracts.Http.Authentication.Requests;

public record RegistrationRequest(string Name, string Login, string Password);