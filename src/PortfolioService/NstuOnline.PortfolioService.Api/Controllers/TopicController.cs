using Microsoft.AspNetCore.Mvc;

namespace NstuOnline.PortfolioService.Api.Controllers;

[ApiController]
[Route("v1/topics")]
public class TopicController : ControllerBase
{
    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id)
    {
        return Ok();
    }
    
    [HttpGet("get-by-portfolio-id/{id}")]
    public IActionResult GetByPortfolioId(Guid id)
    {
        return Ok();
    }
    
    [HttpPost]
    public IActionResult Post()
    {
        return Ok();
    }
    
    [HttpPut]
    public IActionResult Put()
    {
        return Ok();
    }
    
    [HttpDelete("{id:guid}")]
    public IActionResult Delete()
    {
        return Ok();
    }
}