using Common.Data.Repositories;
using NstuOnline.MessageService.Domain.Entities;

namespace NstuOnline.MessageService.Domain.Contracts;

public interface IAttachmentTypeRepository : IDictionaryRepository<AttachmentType, byte>
{
    
}