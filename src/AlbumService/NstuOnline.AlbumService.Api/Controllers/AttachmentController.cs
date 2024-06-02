using Microsoft.AspNetCore.Mvc;

namespace NstuOnline.AlbumService.Api.Controllers;

[ApiController]
[Route("v1/attachment")]
public class AttachmentController : ControllerBase
{
    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id)
    {
        return Ok();
    }
    
    [HttpGet("get-by-user-id/{id:guid}")]
    public IActionResult GetByUserId(Guid id)
    {
        return Ok();
    }
    
    [HttpGet("get-by-topic-id/{id:guid}")]
    public IActionResult GetByTopicId(Guid id)
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