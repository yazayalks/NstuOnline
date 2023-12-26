using NstuOnline.MessageService.ApiClientContracts.Models.AttachmentTypes;
using RestEase;

namespace NstuOnline.MessageService.ApiClientContracts.ApiClients;

public interface IAttachmentTypeApiClient
{
    [Get("/v1/attachment-types")]
    Task<List<AttachmentTypeResponse>> GetAll(CancellationToken cancellationToken = default);
}