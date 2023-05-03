using FluentValidation;

using GigaChat.Contracts.ChatMessages.Requests;
using GigaChat.Contracts.ChatMessages.Responses;
using GigaChat.Contracts.Common.Routes;
using GigaChat.Core.ChatMessages.Commands.CreateChatMessage;
using GigaChat.Core.ChatMessages.Queries.ListChatMessages;
using GigaChat.Core.Entities.ChatMessages;
using GigaChat.Server.Controllers.Common;

using MapsterMapper;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace GigaChat.Server.Controllers;

[Route(ServerRoutes.Controllers.ChatMessageController)]
public class ChatMessageController : ApiController
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public ChatMessageController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ChatMessageResponse>>> ListChatMessages(
        [FromQuery] ListChatMessagesRequest request,
        CancellationToken cancellationToken)
    {
        var query = _mapper.Map<ListChatMessagesQuery>(request);
        var result = await _sender.Send(query, cancellationToken);
        if (result.IsError) return Problem(result.Errors);
        var response = _mapper.Map<IEnumerable<ChatMessageResponse>>(result.Value);
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<ChatMessageResponse>> CreateChatMessage(
        CreateChatMessageRequest request,
        CancellationToken cancellationToken)
    {
        var command = _mapper.Map<CreateChatMessageCommand>(request);
        var result = await _sender.Send(command, cancellationToken);
        return result.IsError ? Problem(result.Errors) : Created(string.Empty, null);
    }
}