using GigaChat.Contracts.Http.Authentication.Requests;
using GigaChat.Contracts.Http.Authentication.Responses;
using GigaChat.Core.Authentication.Commands.Registration;
using GigaChat.Core.Authentication.Queries.Login;

using Mapster;

namespace GigaChat.Server.Mapping.Configurations;

public class AuthenticationMapConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<LoginRequest, LoginQuery>();
        config.NewConfig<LoginResult, LoginResponse>();
        config.NewConfig<RegistrationRequest, RegistrationCommand>();
        config.NewConfig<RegistrationResult, RegistrationResponse>();
    }
}