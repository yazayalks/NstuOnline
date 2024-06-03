using MediatR;
using Microsoft.AspNetCore.Mvc;
using NstuOnline.MessageService.Application.Features.MessageStatuses.GetAll;

namespace NstuOnline.MessageService.Api.Controllers;

[ApiController]
[Route("v1/message-statuses")]
public class MessageStatusController : ControllerBase
{
    private readonly IMediator _mediator;

    public MessageStatusController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public Task<List<MessageStatusResponse>> GetAll(CancellationToken cancellationToken)
    {
        return _mediator.Send(new GetAllMessageStatusesRequest(), cancellationToken);
    }
}