using Microsoft.AspNetCore.Mvc;

namespace NstuOnline.EventService.Api.Controllers;

[ApiController]
[Route("v1/event-types")]
public class EventTypeController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok();
    }
}