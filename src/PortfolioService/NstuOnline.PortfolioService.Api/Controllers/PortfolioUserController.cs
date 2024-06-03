using Microsoft.AspNetCore.Mvc;

namespace NstuOnline.PortfolioService.Api.Controllers;

[ApiController]
[Route("v1/portfolio-users")]
public class PortfolioUserController : ControllerBase
{
    [HttpGet("get-by-ids")]
    public IActionResult GetByIds()
    {
        return Ok();
    }
    
    [HttpPost]
    public IActionResult Create()
    {
        return Ok();
    }

    [HttpDelete("{id:guid}")]
    public IActionResult Delete()
    {
        return Ok();
    }
}
