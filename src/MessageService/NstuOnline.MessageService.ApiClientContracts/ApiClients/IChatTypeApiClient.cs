using NstuOnline.MessageService.ApiClientContracts.Models.ChatTypes;
using RestEase;

namespace NstuOnline.MessageService.ApiClientContracts.ApiClients;

public interface IChatTypeApiClient
{
    [Get("/v1/chat-types")]
    Task<List<ChatTypeResponse>> GetAll(CancellationToken cancellationToken = default);
}