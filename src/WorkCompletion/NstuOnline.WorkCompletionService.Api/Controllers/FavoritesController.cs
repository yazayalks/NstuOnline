using Microsoft.AspNetCore.Mvc;

namespace NstuOnline.WorkCompletion.Api.Controllers;

[ApiController]
[Route("v1/favorites")]
public class FavoritesController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok();
    }
}