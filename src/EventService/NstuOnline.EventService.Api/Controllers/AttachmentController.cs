using Microsoft.AspNetCore.Mvc;

namespace NstuOnline.EventService.Api.Controllers;

[ApiController]
[Route("v1/attachments")]
public class AttachmentController : ControllerBase
{
    [HttpGet("get-by-ids")]
    public IActionResult GetByIds()
    {
        return Ok();
    }
    
    [HttpPost]
    public IActionResult Create()
    {
        return Ok();
    }

    [HttpDelete("{id:guid}")]
    public IActionResult Delete()
    {
        return Ok();
    }
}