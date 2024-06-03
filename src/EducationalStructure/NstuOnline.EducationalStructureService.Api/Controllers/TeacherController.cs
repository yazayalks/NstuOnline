using Microsoft.AspNetCore.Mvc;

namespace NstuOnline.EducationalStructure.Api.Controllers;

[ApiController]
[Route("v1/teachers")]
public class TeacherController : ControllerBase
{
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
    
    [HttpDelete("{id:guid}")]
    public IActionResult Delete()
    {
        return Ok();
    }
}