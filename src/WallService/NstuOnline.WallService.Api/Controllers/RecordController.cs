using Microsoft.AspNetCore.Mvc;

namespace NstuOnline.WallService.Api.Controllers;

[ApiController]
[Route("v1/records")]
public class RecordController : ControllerBase
{
    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id)
    {
        return Ok();
    }
    
    [HttpPost("search")]
    public IActionResult Search()
    {
        return Ok();
    }
    
    [HttpPost]
    public IActionResult Post()
    {
        return Ok();
    }
    
    [HttpPut]
    public IActionResult Put()
    {
        return Ok();
    }
    
    [HttpDelete("{id:guid}")]
    public IActionResult Delete()
    {
        return Ok();
    }
}