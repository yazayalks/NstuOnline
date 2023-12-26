using Common.Data.EntityFramework.Repositories;
using NstuOnline.MessageService.Domain.Contracts;
using NstuOnline.MessageService.Domain.Entities;

namespace NstuOnline.MessageService.Infrastructure.Database.Repositories;

public class ChatTypeRepository : DictionaryRepository<ChatType, byte>, IChatTypeRepository
{
    public ChatTypeRepository(MessageContext context) : base(context)
    {
    }
}