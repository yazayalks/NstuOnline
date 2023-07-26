using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Common.Data.Entities;

namespace Common.Data.Repositories
{
    public interface IRepository<TEntity, in TKey>
        where TEntity : class, IEntity<TKey>
        where TKey : struct
    {
        Task<TEntity> GetById(TKey id, string[] includePaths = null, bool asNoTracking = false, CancellationToken cancellationToken = default);

        Task<List<TEntity>> GetByIds(IEnumerable<TKey> ids, string[] includePaths = null, bool asNoTracking = false, CancellationToken cancellationToken = default);

        Task<TEntity> Add(TEntity entity, CancellationToken cancellationToken = default);

        Task AddRange(IList<TEntity> entities, CancellationToken cancellationToken = default);

        Task Update(TEntity entity, CancellationToken cancellationToken = default);

        Task UpdateRange(IList<TEntity> entities, CancellationToken cancellationToken = default);

        Task Delete(TEntity entity, CancellationToken cancellationToken = default);

        Task DeleteRange(IList<TEntity> entities, CancellationToken cancellationToken = default);

        Task Save(CancellationToken cancellationToken = default);
        
        Task<bool> IsExist(TKey id, CancellationToken cancellationToken = default);
    }
}
