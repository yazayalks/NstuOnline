using Microsoft.AspNetCore.Mvc;

namespace NstuOnline.WallService.Api.Controllers;

[ApiController]
[Route("v1/record-users")]
public class RecordUserController : ControllerBase
{
    [HttpGet("get-by-record-id/{id:guid}")]
    public IActionResult GetByRecordId(Guid id)
    {
        return Ok();
    }
}