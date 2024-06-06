using Common.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NstuOnline.MessageService.Application.Features.Chats.Create;
using NstuOnline.MessageService.Application.Features.Chats.Delete;
using NstuOnline.MessageService.Application.Features.Chats.Search;
using NstuOnline.MessageService.Application.Features.Chats.Update;

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

    [HttpPost("search")]
    public Task<PagedList<SearchChatResponse>> Search(
        SearchChatsRequest request,
        CancellationToken cancellationToken)
    {
        return _mediator.Send(request, cancellationToken);
    }

    [HttpPost]
    public Task<Guid> Create(
        CreateChatRequest request,
        CancellationToken cancellationToken)
    {
        return _mediator.Send(request, cancellationToken);
    }

    [HttpPut]
    public Task<Guid> Update([FromBody] UpdateChatRequest request)
    {
        return _mediator.Send(request);
    }

    [HttpDelete("{id:guid}")]
    public Task Delete([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        return _mediator.Send(new DeleteChatRequest(id), cancellationToken);
    }
}