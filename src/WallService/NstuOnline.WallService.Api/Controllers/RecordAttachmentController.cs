using Microsoft.AspNetCore.Mvc;

namespace NstuOnline.WallService.Api.Controllers;

[ApiController]
[Route("v1/record-attachments")]
public class RecordAttachmentController : ControllerBase
{
    [HttpGet("get-by-record/{id}")]
    public IActionResult Get()
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