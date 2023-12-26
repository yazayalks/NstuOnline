using Common.Models;
using NstuOnline.MessageService.ApiClientContracts.Models.Messages;
using RestEase;

namespace NstuOnline.MessageService.ApiClientContracts.ApiClients;

public interface IMessageApiClient
{
    [Post("v1/messages")]
    Task<Guid> Create([Body] CreateMessageRequest request,
        CancellationToken cancellationToken = default);

    [Post("v1/messages/search")]
    Task<PagedList<SearchMessageResponse>> Search([Body] SearchMessageRequest request,
        CancellationToken cancellationToken = default);
}