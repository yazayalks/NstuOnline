using Microsoft.AspNetCore.Mvc;

namespace NstuOnline.EducationalStructure.Api.Controllers;

[ApiController]
[Route("v1/teacher-assignments")]
public class TeachingAssignmentController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok();
    }
        
    [HttpGet("get-by-teacher/{id:guid}")]
    public IActionResult GetByTeacher()
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
    
    [HttpGet("add/{id:guid}")]
    public IActionResult Add()
    {
        return Ok();
    }
    
    [HttpGet("remove/{id:guid}")]
    public IActionResult Remove()
    {
        return Ok();
    }
    
    [HttpDelete("{id:guid}")]
    public IActionResult Delete()
    {
        return Ok();
    }
}