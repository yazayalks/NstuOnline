using Common.Data.EntityFramework.Repositories;
using NstuOnline.MessageService.Domain.Contracts;
using NstuOnline.MessageService.Domain.Entities;

namespace NstuOnline.MessageService.Infrastructure.Database.Repositories;

public class AttachmentTypeRepository : DictionaryRepository<AttachmentType, byte>, IAttachmentTypeRepository
{
    public AttachmentTypeRepository(MessageContext context) : base(context)
    {
    }
}