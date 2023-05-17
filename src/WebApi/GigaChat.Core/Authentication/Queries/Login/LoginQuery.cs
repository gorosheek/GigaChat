using ErrorOr;

using MediatR;

namespace GigaChat.Core.Authentication.Queries.Login;

public record LoginQuery(string Login, string Password)
    : IRequest<ErrorOr<LoginResult>>;