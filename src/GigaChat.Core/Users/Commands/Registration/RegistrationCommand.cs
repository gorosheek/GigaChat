using ErrorOr;

using MediatR;

namespace GigaChat.Core.Users.Commands.Registration;

public record RegistrationCommand(string Name, string Login, string Password)
    : IRequest<ErrorOr<Created>>;