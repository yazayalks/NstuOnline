using NstuOnline.BFF.Application.Services.ChatType.Models;

namespace NstuOnline.BFF.Application.Services.ChatType;

public interface IChatTypeService
{
    Task<List<ChatTypeResponse>> GetAll(CancellationToken cancellationToken = default);
}