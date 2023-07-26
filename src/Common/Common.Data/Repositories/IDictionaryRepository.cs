using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Common.Data.Entities;
using Common.Models;

namespace Common.Data.Repositories
{
    public interface IDictionaryRepository<TEntity, TKey>
        where TEntity : class, IDictionaryEntity<TKey>
        where TKey : struct
    {
        Task<IList<TEntity>> GetAll(SortExpression sortExpression = null, CancellationToken cancellationToken = default);
        
        Task<TEntity> GetById(TKey id, bool asNoTracking = false, CancellationToken cancellationToken = default);
        
        Task<bool> IsExist(TKey id, CancellationToken cancellationToken = default);
    }
}
