using Microsoft.AspNetCore.Mvc;

namespace NstuOnline.WallService.Api.Controllers;

[ApiController]
[Route("v1/attachment-users")]
public class AttachmentUserController : ControllerBase
{
    [HttpGet("get-by-attachment-id/{id:guid}")]
    public IActionResult GetByAttachmentId(Guid id)
    {
        return Ok();
    }
}