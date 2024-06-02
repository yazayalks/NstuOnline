﻿using Microsoft.AspNetCore.Mvc;

namespace NstuOnline.AlbumService.Api.Controllers;

[ApiController]
[Route("v1/album")]
public class AlbumController : ControllerBase
{
    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id)
    {
        return Ok();
    }
    
    [HttpGet]
    public IActionResult Get()
    {
        return Ok();
    }
    
    [HttpPut]
    public IActionResult Put()
    {
        return Ok();
    }
    
    [HttpPut("like/{id:guid}")]
    public IActionResult Like(Guid id)
    {
        return Ok();
    }
    
    [HttpDelete("{id:guid}")]
    public IActionResult Delete()
    {
        return Ok();
    }
}