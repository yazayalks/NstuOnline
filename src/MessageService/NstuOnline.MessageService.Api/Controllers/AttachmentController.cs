using MediatR;
using Microsoft.AspNetCore.Mvc;

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
}