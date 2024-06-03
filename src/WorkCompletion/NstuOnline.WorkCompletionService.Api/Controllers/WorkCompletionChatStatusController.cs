using Microsoft.AspNetCore.Mvc;

namespace NstuOnline.WorkCompletion.Api.Controllers;

[ApiController]
[Route("v1/work-completion-chat-statuses")]
public class WorkCompletionChatStatusController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok();
    }
}