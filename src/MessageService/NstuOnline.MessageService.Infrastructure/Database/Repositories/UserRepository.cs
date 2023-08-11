using Microsoft.EntityFrameworkCore;
using NstuOnline.MessageService.Domain.Contracts;
using NstuOnline.MessageService.Domain.Entities;

namespace NstuOnline.MessageService.Infrastructure.Database.Repositories;

public class UserRepository : IUserRepository
{
    private readonly MessageContext _context;
    private readonly DbSet<User> _dbSet;
    
    public UserRepository(MessageContext context)
    {
        _context = context;
        _dbSet = context.Set<User>();
    }

    public async Task<List<User>> GetByIds(IEnumerable<Guid> ids, CancellationToken cancellationToken)
    {
        return await _dbSet
            .AsNoTracking()
            .Where(x => ids.Contains(x.UserId))
            .ToListAsync(cancellationToken);
    }
}