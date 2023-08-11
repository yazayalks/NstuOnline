using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using NstuOnline.MessageService.Domain.Entities;

namespace NstuOnline.MessageService.Domain.Contracts;

public interface IUserRepository
{
    Task<List<User>> GetByIds(IEnumerable<Guid> ids, CancellationToken cancellationToken);
}