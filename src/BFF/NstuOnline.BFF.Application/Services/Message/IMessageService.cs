using Common.Models;
using NstuOnline.BFF.Application.Services.Message.Models;

namespace NstuOnline.BFF.Application.Services.Message;

public interface IMessageService
{
    Task<Guid> Create(CreateMessageRequest request, CancellationToken cancellationToken);

    Task<PagedList<SearchMessageResponse>> Search(SearchMessageRequest request, CancellationToken cancellationToken);
}