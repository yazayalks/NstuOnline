using Microsoft.AspNetCore.Mvc;

namespace NstuOnline.WorkCompletion.Api.Controllers;

[ApiController]
[Route("v1/work-completion-results")]
public class WorkCompletionResultController : ControllerBase
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

    [HttpPut]
    public IActionResult Update()
    {
        return Ok();
    }

    [HttpDelete("{id:guid}")]
    public IActionResult Delete()
    {
        return Ok();
    }
}