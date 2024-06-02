using Microsoft.AspNetCore.Mvc;

namespace NstuOnline.EducationalStructure.Api.Controllers;

[ApiController]
[Route("v1/study-level")]
public class StudyLevelController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok();
    }
}