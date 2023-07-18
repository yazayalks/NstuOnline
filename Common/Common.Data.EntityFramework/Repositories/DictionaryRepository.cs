using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Common.Data.Entities;
using Common.Data.Extensions;
using Common.Data.Repositories;
using Common.Models;
using Microsoft.EntityFrameworkCore;

namespace Common.Data.EntityFramework.Repositories
{
    public class DictionaryRepository<TEntity, TKey> : IDictionaryRepository<TEntity, TKey>
        where TEntity : class, IDictionaryEntity<TKey>
        where TKey : struct
    {
        protected readonly DbContext Context;
        protected readonly DbSet<TEntity> EntitiesDbSet;

        public DictionaryRepository(DbContext context)
        {
            Context = context;
            EntitiesDbSet = context.Set<TEntity>();
        }

        public async Task<IList<TEntity>> GetAll(SortExpression sortExpression = null,
            CancellationToken cancellationToken = default)
        {
            var expressions = sortExpression == null
                ? null
                : new[] { sortExpression };

            return await EntitiesDbSet
                .AsNoTracking()
                .OrderByExpressions(expressions)
                .ToListAsync(cancellationToken);
        }

        public Task<TEntity> GetById(TKey id, bool asNoTracking = false, CancellationToken cancellationToken = default)
        {
            return (asNoTracking ? EntitiesDbSet.AsNoTracking() : EntitiesDbSet)
                .SingleOrDefaultAsync(x => x.Id.Equals(id), cancellationToken);
        }

        public Task<bool> IsExist(TKey id, CancellationToken cancellationToken = default)
        {
            return EntitiesDbSet
                .AsNoTracking()
                .AnyAsync(x => x.Id.Equals(id), cancellationToken);
        }
    }
}