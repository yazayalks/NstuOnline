using Microsoft.AspNetCore.Mvc;

namespace NstuOnline.AlbumService.Api.Controllers;

[ApiController]
[Route("v1/attachments")]
public class AttachmentController : ControllerBase
{
    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id)
    {
        return Ok();
    }

    [HttpPost]
    public IActionResult Post()
    {
        return Ok();
    }
    
    [HttpDelete("{id:guid}")]
    public IActionResult Delete()
    {
        return Ok();
    }
}