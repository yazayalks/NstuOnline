using Common.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NstuOnline.MessageService.Application.Features.Chats.Create;
using NstuOnline.MessageService.Application.Features.Chats.Search;

namespace NstuOnline.MessageService.Api.Controllers;

[ApiController]
[Route("v1/chats")]
public class ChatController : ControllerBase
{
    private readonly IMediator _mediator;

    public ChatController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public Task<Guid> Create(CreateChatRequest request, CancellationToken cancellationToken)
    {
        return _mediator.Send(request, cancellationToken);
    }
    
    [HttpPost("search")]
    public Task<PagedList<SearchChatsResponse>> Search(SearchChatsRequest request, CancellationToken cancellationToken)
    {
        return _mediator.Send(request, cancellationToken);
    }
}