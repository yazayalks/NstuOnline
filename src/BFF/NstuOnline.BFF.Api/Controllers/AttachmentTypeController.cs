using Microsoft.AspNetCore.Mvc;
using NstuOnline.BFF.Application.Services.AttachmentType;
using NstuOnline.BFF.Application.Services.AttachmentType.Models;

namespace NstuOnline.BFF.Api.Controllers;

[ApiController]
[Route("v1/attachment-types")]
public class AttachmentTypeController : ControllerBase
{
    private readonly IAttachmentTypeService _attachmentTypeService;

    public AttachmentTypeController(IAttachmentTypeService attachmentTypeService)
    {
        _attachmentTypeService = attachmentTypeService;
    }

    [HttpGet]
    public Task<List<AttachmentTypeResponse>> GetAll(CancellationToken cancellationToken)
    {
        return _attachmentTypeService.GetAll(cancellationToken);
    }
}