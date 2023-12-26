using MediatR;
using Microsoft.AspNetCore.Mvc;
using NstuOnline.MessageService.Application.Features.ChatTypes.GetAll;

namespace NstuOnline.MessageService.Api.Controllers;

[ApiController]
[Route("v1/chat-types")]
public class ChatTypeController : ControllerBase
{
    private readonly IMediator _mediator;

    public ChatTypeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public Task<List<ChatTypeResponse>> GetAll(CancellationToken cancellationToken)
    {
        return _mediator.Send(new GetAllChatTypesRequest(), cancellationToken);
    }
}