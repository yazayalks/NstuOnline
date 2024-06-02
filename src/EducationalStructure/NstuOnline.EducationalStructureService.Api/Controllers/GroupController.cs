using Microsoft.AspNetCore.Mvc;

namespace NstuOnline.EducationalStructure.Api.Controllers;

[ApiController]
[Route("v1/group")]
public class GroupController : ControllerBase
{
    [HttpGet("search")]
    public IActionResult Search()
    {
        return Ok();
    }
    
    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id)
    {
        return Ok();
    }
    
    [HttpGet]
    public IActionResult Get()
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