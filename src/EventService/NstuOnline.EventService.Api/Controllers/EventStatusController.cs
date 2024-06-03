using Microsoft.AspNetCore.Mvc;

namespace NstuOnline.EventService.Api.Controllers;

[ApiController]
[Route("v1/event-statuses")]
public class EventStatusController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok();
    }
}