using AutoMapper;
using NstuOnline.BFF.Application.Services.AttachmentType.Models;
using NstuOnline.MessageService.ApiClientContracts.ApiClients;

namespace NstuOnline.BFF.Application.Services.AttachmentType;

public class AttachmentTypeService : IAttachmentTypeService
{
    private readonly IAttachmentTypeApiClient _attachmentTypeApiClient;
    private readonly IMapper _mapper;

    public AttachmentTypeService(IAttachmentTypeApiClient attachmentTypeApiClient, IMapper mapper)
    {
        _attachmentTypeApiClient = attachmentTypeApiClient;
        _mapper = mapper;
    }

    public async Task<List<AttachmentTypeResponse>> GetAll(CancellationToken cancellationToken = default)
    {
        var allAttachmentTypes = await _attachmentTypeApiClient.GetAll(cancellationToken);

        return _mapper.Map<List<AttachmentTypeResponse>>(allAttachmentTypes);
    }
}