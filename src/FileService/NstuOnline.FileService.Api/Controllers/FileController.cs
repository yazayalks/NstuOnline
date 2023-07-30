using MediatR;
using Microsoft.AspNetCore.Mvc;
using NstuOnline.FileService.Application.Features.Files.GetUrlById;
using NstuOnline.FileService.Application.Features.Files.Upload;
using NstuOnline.FileService.Application.Features.Files.UploadFromBase64;

namespace NstuOnline.FileService.Api.Controllers;

[ApiController]
[Route("v1/files")]
public class FileController : ControllerBase
{
    private readonly IMediator _mediator;

    public FileController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id:guid}")]
    public Task<string> GetUrlById([FromRoute] Guid id, [FromQuery] Guid usedId, CancellationToken cancellationToken)
    {
        return _mediator.Send(new GetFileUrlByIdRequest(id, usedId), cancellationToken);
    }

    [HttpPost("upload")]
    public Task Upload(IFormFile file, [FromQuery] Guid usedId, CancellationToken cancellationToken)
    {
        return _mediator.Send(new UploadFileRequest(file, usedId), cancellationToken);
    }
    
    [HttpPost("upload-from-base64")]
    public Task<Guid> UploadFromBase64([FromBody] UploadFromBase64Request request, CancellationToken cancellationToken)
    {
        return _mediator.Send(request, cancellationToken);
    }
}