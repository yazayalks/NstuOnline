using Microsoft.AspNetCore.Mvc;

namespace NstuOnline.EducationalStructure.Api.Controllers;

[ApiController]
[Route("v1/topic-attachment")]
public class TopicAttachmentController : ControllerBase
{
    [HttpGet("get-by-topic/{id}")]
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