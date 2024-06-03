using Common.Data.EntityFramework.Repositories;

using NstuOnline.MessageService.Domain.Contracts;
using NstuOnline.MessageService.Domain.Entities;

namespace NstuOnline.MessageService.Infrastructure.Database.Repositories;

public class MessageTypeRepository : DictionaryRepository<MessageType, byte>, IMessageTypeRepository
{
    public MessageTypeRepository(MessageContext context) : base(context)
    {
    }
}