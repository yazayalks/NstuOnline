using Microsoft.AspNetCore.Mvc;

namespace NstuOnline.WorkCompletion.Api.Controllers;

[ApiController]
[Route("v1/work-completion-statuses")]
public class WorkCompletionStatusController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok();
    }
}