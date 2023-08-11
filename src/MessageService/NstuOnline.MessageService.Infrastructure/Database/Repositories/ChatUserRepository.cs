using Microsoft.EntityFrameworkCore;
using NstuOnline.MessageService.Domain.Contracts;
using NstuOnline.MessageService.Domain.Entities;

namespace NstuOnline.MessageService.Infrastructure.Database.Repositories;

public class ChatUserRepository : IChatUserRepository
{
    private readonly MessageContext _context;
    private readonly DbSet<ChatUser> _dbSet;

    public ChatUserRepository(MessageContext context)
    {
        _context = context;
        _dbSet = context.Set<ChatUser>();
    }

    public async Task<ChatUser> Get(Guid userId, Guid chatId, CancellationToken cancellationToken)
    {
        return await _dbSet
            .AsNoTracking()
            .SingleOrDefaultAsync(x => x.UserId == userId && x.ChatId == chatId, cancellationToken);
    }
}