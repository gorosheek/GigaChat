using ErrorOr;

using MediatR;

namespace GigaChat.Core.Authentication.Commands.Registration;

public record RegistrationCommand(string Name, string Login, string Password)
    : IRequest<ErrorOr<RegistrationResult>>;