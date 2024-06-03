using Common.Data.EntityFramework.Repositories;
using NstuOnline.MessageService.Domain.Contracts;
using NstuOnline.MessageService.Domain.Entities;

namespace NstuOnline.MessageService.Infrastructure.Database.Repositories;

public class MessageStatusRepository : DictionaryRepository<MessageStatus, byte>, IMessageStatusRepository
{
    public MessageStatusRepository(MessageContext context) : base(context)
    {
    }
}