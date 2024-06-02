﻿using Microsoft.AspNetCore.Mvc;

namespace NstuOnline.EducationalStructure.Api.Controllers;

[ApiController]
[Route("v1/attachment-type")]
public class AttachmentController : ControllerBase
{
    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id)
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