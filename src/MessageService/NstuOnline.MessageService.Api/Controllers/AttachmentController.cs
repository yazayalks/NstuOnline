using MediatR;
using Microsoft.AspNetCore.Mvc;
using NstuOnline.MessageService.Application.Features.Attachments.Create;

namespace NstuOnline.MessageService.Api.Controllers;

[ApiController]
[Route("v1/attachments")]
public class AttachmentController : ControllerBase
{
    private readonly IMediator _mediator;

    public AttachmentController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost]
    public Task<Guid> Create(CreateAttachmentRequest request, CancellationToken cancellationToken)
    {
        return _mediator.Send(request, cancellationToken);
    }
}