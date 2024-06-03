using Microsoft.AspNetCore.Mvc;

namespace NstuOnline.WorkCompletion.Api.Controllers;

[ApiController]
[Route("v1/attachments")]
public class AttachmentController : ControllerBase
{
    [HttpGet("get-by-id")]
    public IActionResult GetById()
    {
        return Ok();
    }
    
    [HttpGet("get-by-ids")]
    public IActionResult GetByIds()
    {
        return Ok();
    }
    
    [HttpPost("search")]
    public IActionResult Search()
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