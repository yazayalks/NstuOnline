using Microsoft.AspNetCore.Mvc;

namespace NstuOnline.PortfolioService.Api.Controllers;

[ApiController]
[Route("v1/portfolio-types")]
public class PortfolioTypeController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok();
    }
}