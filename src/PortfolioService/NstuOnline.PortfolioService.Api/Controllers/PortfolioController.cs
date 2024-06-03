using Microsoft.AspNetCore.Mvc;

namespace NstuOnline.PortfolioService.Api.Controllers;

[ApiController]
[Route("v1/portfolios")]
public class PortfolioController : ControllerBase
{
    [HttpGet("get-by-id/{id:guid}")]
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
