using Common.Models;
using NstuOnline.BFF.Application.Services.Chat.Models;

namespace NstuOnline.BFF.Application.Services.Chat;

public interface IChatService
{
    Task<Guid> Create(CreateChatRequest request, CancellationToken cancellationToken);

    Task<PagedList<SearchChatsResponse>> Search(SearchChatsRequest request, CancellationToken cancellationToken);
}