using Common.Models;
using Microsoft.AspNetCore.Mvc;
using NstuOnline.BFF.Application.Services.Message;
using NstuOnline.BFF.Application.Services.Message.Models;

namespace NstuOnline.BFF.Api.Controllers;

[ApiController]
[Route("v1/messages")]
public class MessageController
{
    private readonly IMessageService _messageService;

    public MessageController(IMessageService messageService)
    {
        _messageService = messageService;
    }


    [HttpPost]
    public Task<Guid> Create(CreateMessageRequest request, CancellationToken cancellationToken)
    {
        return _messageService.Create(request, cancellationToken);
    }

    [HttpPost("search")]
    public async Task<PagedList<SearchMessageResponse>> Search(SearchMessageRequest request,
        CancellationToken cancellationToken)
    {
        return await _messageService.Search(request, cancellationToken);
    }
}