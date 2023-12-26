using Microsoft.AspNetCore.Mvc;
using NstuOnline.BFF.Application.Services.ChatType;
using NstuOnline.BFF.Application.Services.ChatType.Models;

namespace NstuOnline.BFF.Api.Controllers;

[ApiController]
[Route("v1/chat-types")]
public class ChatTypeController : ControllerBase
{
    private readonly IChatTypeService _chatTypeService;

    public ChatTypeController(IChatTypeService chatTypeService)
    {
        _chatTypeService = chatTypeService;
    }

    [HttpGet]
    public Task<List<ChatTypeResponse>> GetAll(CancellationToken cancellationToken)
    {
        return _chatTypeService.GetAll(cancellationToken);
    }
}