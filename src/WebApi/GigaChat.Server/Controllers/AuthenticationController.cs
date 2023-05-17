using GigaChat.Contracts.Authentication.Requests;
using GigaChat.Contracts.Authentication.Responses;
using GigaChat.Contracts.Common.Routes;
using GigaChat.Core.Authentication.Commands.Registration;
using GigaChat.Core.Authentication.Queries.Login;
using GigaChat.Server.Controllers.Common;

using MapsterMapper;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GigaChat.Server.Controllers;

[Route(ServerRoutes.Controllers.AuthenticationController)]
public class AuthenticationController : ApiController
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public AuthenticationController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpPost("register")]
    [AllowAnonymous]
    public async Task<ActionResult<RegistrationResponse>> Registration(RegistrationRequest request, CancellationToken cancellationToken)
    {
        var command = _mapper.Map<RegistrationCommand>(request);
        var result = await _sender.Send(command, cancellationToken);
        if (result.IsError) return Problem(result.Errors);
        var response = _mapper.Map<RegistrationResponse>(result.Value);
        return Created(string.Empty, response);
    }

    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<ActionResult<LoginResponse>> Login(LoginRequest request, CancellationToken cancellationToken)
    {
        var command = _mapper.Map<LoginQuery>(request);
        var result = await _sender.Send(command, cancellationToken);
        if (result.IsError) return Problem(result.Errors);
        var response = _mapper.Map<LoginResponse>(result.Value);
        return Ok(response);
    }
}