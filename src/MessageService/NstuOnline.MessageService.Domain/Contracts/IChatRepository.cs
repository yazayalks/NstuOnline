using System;
using System.Threading;
using System.Threading.Tasks;
using Common.Data.Repositories;
using Common.Models;
using NstuOnline.MessageService.Domain.Entities;
using NstuOnline.MessageService.Domain.Models;

namespace NstuOnline.MessageService.Domain.Contracts;

public interface IChatRepository : IRepository<Chat, Guid>
{
    Task<PagedList<Chat>> Search(SearchChatCriteria criteria, CancellationToken cancellationToken);
}