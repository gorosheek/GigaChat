using GigaChat.Contracts.Common.Routes;
using GigaChat.Contracts.Users.Requests;
using GigaChat.Contracts.Users.Responses;
using GigaChat.Core.Users.Commands.Registration;
using GigaChat.Core.Users.Commands.SoftDeleteUser;
using GigaChat.Core.Users.Commands.UpdateUsername;
using GigaChat.Core.Users.Queries.ListUsers;
using GigaChat.Server.Controllers.Common;

using MapsterMapper;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace GigaChat.Server.Controllers;

[Route(ServerRoutes.Controllers.UserController)]
public class UserController : ApiController
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public UserController(IMapper mapper, ISender sender)
    {
        _mapper = mapper;
        _sender = sender;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserResponse>>> ListUsers(CancellationToken cancellationToken)
    {
        var query = new ListUsersQuery();
        var result = await _sender.Send(query, cancellationToken);
        if (result.IsError) return Problem(result.Errors);
        var response = _mapper.Map<IEnumerable<UserResponse>>(result.Value);
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult> Registration(RegistrationUserRequest request, CancellationToken cancellationToken)
    {
        var command = _mapper.Map<RegistrationCommand>(request);
        var result = await _sender.Send(command, cancellationToken);
        return result.IsError ? Problem(result.Errors) : Created(string.Empty, null);
    }

    [HttpPatch]
    public async Task<ActionResult> UpdateUsername(UpdateUsernameRequest request, CancellationToken cancellationToken)
    {
        var command = _mapper.Map<UpdateUsernameCommand>(request);
        var result = await _sender.Send(command, cancellationToken);
        return result.IsError ? Problem(result.Errors) : NoContent();
    }

    [HttpDelete]
    public async Task<ActionResult> SoftDeleteUser(SoftDeleteUserRequest request, CancellationToken cancellationToken)
    {
        var command = _mapper.Map<SoftDeleteUserCommand>(request);
        var result = await _sender.Send(command, cancellationToken);
        return result.IsError ? Problem(result.Errors) : NoContent();
    }
}