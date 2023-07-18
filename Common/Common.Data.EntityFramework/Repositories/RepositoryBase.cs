using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Common.Data.Entities;
using Common.Data.EntityFramework.Extensions;
using Common.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Common.Data.EntityFramework.Repositories
{
    public class RepositoryBase<TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
        where TKey : struct
    {
        protected readonly DbContext Context;
        protected readonly DbSet<TEntity> EntitiesDbSet;

        protected RepositoryBase(DbContext context)
        {
            Context = context;
            EntitiesDbSet = context.Set<TEntity>();
        }

        public virtual async Task<TEntity> Add(TEntity entity, CancellationToken cancellationToken = default)
        {
            var entry = await EntitiesDbSet.AddAsync(entity, cancellationToken);
            await Save(cancellationToken);

            return entry.Entity;
        }

        public virtual async Task AddRange(IList<TEntity> entities, CancellationToken cancellationToken = default)
        {
            await EntitiesDbSet.AddRangeAsync(entities, cancellationToken);

            await Save(cancellationToken);
        }

        public virtual async Task Update(TEntity entity, CancellationToken cancellationToken = default)
        {
            EntitiesDbSet.Update(entity);

            await Save(cancellationToken);
        }

        public virtual async Task UpdateRange(IList<TEntity> entities, CancellationToken cancellationToken = default)
        {
            EntitiesDbSet.UpdateRange(entities);

            await Save(cancellationToken);
        }

        public virtual Task<TEntity> GetById(TKey id, string[] includePaths = null, bool asNoTracking = false,
            CancellationToken cancellationToken = default)
        {
            var entities = (asNoTracking ? EntitiesDbSet.AsNoTracking() : EntitiesDbSet)
                .AsQueryable()
                .AddIncludes<TEntity, TKey>(includePaths);

            return entities.SingleOrDefaultAsync(x => x.Id.Equals(id), cancellationToken);
        }

        public virtual Task<List<TEntity>> GetByIds(IEnumerable<TKey> ids, string[] includePaths = null,
            bool asNoTracking = false, CancellationToken cancellationToken = default)
        {
            var entities = (asNoTracking ? EntitiesDbSet.AsNoTracking() : EntitiesDbSet)
                .AsQueryable()
                .AddIncludes<TEntity, TKey>(includePaths);

            return entities.Where(x => ids.Contains(x.Id)).ToListAsync(cancellationToken);
        }

        public virtual async Task Delete(TEntity entity, CancellationToken cancellationToken = default)
        {
            EntitiesDbSet.Remove(entity);

            await Save(cancellationToken);
        }

        public virtual async Task DeleteRange(IList<TEntity> entities, CancellationToken cancellationToken = default)
        {
            EntitiesDbSet.RemoveRange(entities);

            await Save(cancellationToken);
        }

        public virtual Task Save(CancellationToken cancellationToken = default)
        {
            return Context.SaveChangesAsync(cancellationToken);
        }

        public virtual Task<bool> IsExist(TKey id, CancellationToken cancellationToken = default)
        {
            return EntitiesDbSet
                .AsNoTracking()
                .AnyAsync(x => x.Id.Equals(id), cancellationToken);
        }
    }
}