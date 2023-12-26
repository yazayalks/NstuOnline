using MediatR;
using Microsoft.AspNetCore.Mvc;
using NstuOnline.MessageService.Application.Features.AttachmentTypes.GetAll;

namespace NstuOnline.MessageService.Api.Controllers;

[ApiController]
[Route("v1/attachment-types")]
public class AttachmentTypeController : ControllerBase
{
    private readonly IMediator _mediator;

    public AttachmentTypeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public Task<List<AttachmentTypeResponse>> GetAll(CancellationToken cancellationToken)
    {
        return _mediator.Send(new GetAllAttachmentTypesRequest(), cancellationToken);
    }
}