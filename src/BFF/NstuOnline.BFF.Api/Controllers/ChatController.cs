using System.Security.Claims;
using Common.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NstuOnline.BFF.Application.Services.Chat;
using NstuOnline.BFF.Application.Services.Chat.Models;
using NstuOnline.BFF.Domain.Entity;

namespace NstuOnline.BFF.Api.Controllers;

[ApiController]
[Route("v1/chats")]
public class ChatController : ControllerBase
{
    private readonly IChatService _chatService;
    private readonly UserManager<User> _userManager;
    
    public ChatController(IChatService chatService, UserManager<User> userManager)
    {
        _chatService = chatService;
        _userManager = userManager;
    }

    [HttpPost]
    public Task<Guid> Create(CreateChatRequest request, CancellationToken cancellationToken)
    {
        return _chatService.Create(request, cancellationToken);
    }
    
    [HttpPost("search")]
    public async Task<PagedList<SearchChatResponse>> Search(SearchChatRequest request, CancellationToken cancellationToken)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        request.UserId = Guid.Parse(userId!);
        return await _chatService.Search(request, cancellationToken);
    }
}