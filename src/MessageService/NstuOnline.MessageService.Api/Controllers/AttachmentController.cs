using MediatR;
using Microsoft.AspNetCore.Mvc;
using NstuOnline.MessageService.Application.Features.Attachments.Upload;

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

    [HttpPost("upload")]
    public Task Upload(IFormFile file, Guid usedId, CancellationToken cancellationToken)
    {
        return _mediator.Send(new UploadAttachmentRequest(file, usedId), cancellationToken);
    }
}