using Microsoft.AspNetCore.Mvc;

namespace NstuOnline.EducationalStructure.Api.Controllers;

[ApiController]
[Route("v1/student")]
public class StudentController : ControllerBase
{
    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id)
    {
        return Ok();
    }
        
    [HttpGet("search")]
    public IActionResult Search()
    {
        return Ok();
    }
    
    [HttpGet]
    public IActionResult Get()
    {
        return Ok();
    }
}