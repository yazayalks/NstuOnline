using Common.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NstuOnline.MessageService.Application.Features.Messages.ChangeStatus;
using NstuOnline.MessageService.Application.Features.Messages.Create;
using NstuOnline.MessageService.Application.Features.Messages.Delete;
using NstuOnline.MessageService.Application.Features.Messages.Search;

namespace NstuOnline.MessageService.Api.Controllers;

[ApiController]
[Route("v1/messages")]
public class MessageController : ControllerBase
{
    private readonly IMediator _mediator;

    public MessageController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public Task<Guid> Create(CreateMessageRequest request, CancellationToken cancellationToken)
    {
        return _mediator.Send(request, cancellationToken);
    }
    
    [HttpPost("search")]
    public Task<PagedList<SearchMessageResponse>> Search(SearchMessageRequest request, CancellationToken cancellationToken)
    {
        return _mediator.Send(request, cancellationToken);
    }
    
    [HttpPut("{id:guid}/status")]
    public Task ChangeStatus([FromRoute] Guid id, [FromQuery] byte statusId)
    {
        return _mediator.Send(new ChangeMessageStatusRequest(id, statusId));
    }
    
    [HttpDelete("{id:guid}")]
    public Task Delete([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        return _mediator.Send(new DeleteMessageRequest(id), cancellationToken);
    }
}