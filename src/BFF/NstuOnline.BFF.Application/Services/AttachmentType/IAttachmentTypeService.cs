using NstuOnline.BFF.Application.Services.AttachmentType.Models;

namespace NstuOnline.BFF.Application.Services.AttachmentType;

public interface IAttachmentTypeService
{
    Task<List<AttachmentTypeResponse>> GetAll(CancellationToken cancellationToken = default);
}