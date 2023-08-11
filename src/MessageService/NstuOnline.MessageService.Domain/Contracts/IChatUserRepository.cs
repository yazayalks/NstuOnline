using System;
using System.Threading;
using System.Threading.Tasks;
using NstuOnline.MessageService.Domain.Entities;

namespace NstuOnline.MessageService.Domain.Contracts;

public interface IChatUserRepository
{
    Task<ChatUser> Get(Guid userId, Guid chatId, CancellationToken cancellationToken);
}