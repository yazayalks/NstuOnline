using MediatR;
using Microsoft.AspNetCore.Mvc;
using NstuOnline.MessageService.Application.Features.MessageTypes.GetAll;

namespace NstuOnline.MessageService.Api.Controllers;

[ApiController]
[Route("v1/message-types")]
public class MessageTypeController : ControllerBase
{
    private readonly IMediator _mediator;

    public MessageTypeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public Task<List<MessageTypeResponse>> GetAll(CancellationToken cancellationToken)
    {
        return _mediator.Send(new GetAllMessageTypesRequest(), cancellationToken);
    }
}