using Common.Models;
using NstuOnline.MessageService.ApiClientContracts.Models.Chats;
using RestEase;

namespace NstuOnline.MessageService.ApiClientContracts.ApiClients;

public interface IChatApiClient
{
    [Post("v1/chats")]
    Task<Guid> Create([Body] CreateChatRequest request,
        CancellationToken cancellationToken = default);

    [Post("v1/chats/search")]
    Task<PagedList<SearchChatsResponse>> Search([Body] SearchChatsRequest request,
        CancellationToken cancellationToken = default);
}