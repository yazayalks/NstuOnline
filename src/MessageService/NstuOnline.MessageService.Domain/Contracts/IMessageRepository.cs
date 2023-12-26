using System;
using System.Threading;
using System.Threading.Tasks;
using Common.Data.Repositories;
using Common.Models;
using NstuOnline.MessageService.Domain.Entities;
using NstuOnline.MessageService.Domain.Models;

namespace NstuOnline.MessageService.Domain.Contracts;

public interface IMessageRepository  : IRepository<Message, Guid>
{
    Task <PagedList<Message>> Search(SearchMessageCriteria criteria, CancellationToken cancellationToken);
    
    Task <PagedList<Message>> SimplifySearch(SimplifySearchMessageCriteria criteria, CancellationToken cancellationToken);
}

