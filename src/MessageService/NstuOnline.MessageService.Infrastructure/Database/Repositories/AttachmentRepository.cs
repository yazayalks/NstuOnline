using Common.Data.EntityFramework.Repositories;
using NstuOnline.MessageService.Domain.Contracts;
using NstuOnline.MessageService.Domain.Entities;

namespace NstuOnline.MessageService.Infrastructure.Database.Repositories;

public class AttachmentRepository : RepositoryBase<Attachment, Guid>, IAttachmentRepository
{
    public AttachmentRepository(MessageContext context) : base(context)
    {
    }
}