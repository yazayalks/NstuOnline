using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Common.Data.Entities;
using Common.Data.Extensions;
using Common.Models;
using Microsoft.EntityFrameworkCore;

namespace Common.Data.EntityFramework.Extensions
{
    public static class QueryableExtensions
    {
        public static Task<PagedList<T>> ToSearchResult<T>(this IQueryable<T> query,
            int skip, int take, CancellationToken cancellationToken = default) 
            where T : class
        {
            return query.ToSearchResult((SortExpression[])null, skip, take, cancellationToken);
        }

        public static Task<PagedList<T>> ToSearchResult<T>(this IQueryable<T> query,
            SortExpression sortExpression, int skip, int take, CancellationToken cancellationToken = default)
            where T : class
        {
            var expressions = sortExpression == null
                ? null
                : new[] { sortExpression };

            return query.ToSearchResult(expressions, skip, take, cancellationToken);
        }

        public static async Task<PagedList<T>> ToSearchResult<T>(this IQueryable<T> query,
            IList<SortExpression> sortExpressions, int skip, int take, CancellationToken cancellationToken = default) 
            where T : class
        {
            var result = new PagedList<T>
            {
                TotalCount = await query.CountAsync(cancellationToken)
            };

            if (take > 0)
            {
                result.Items = await query
                    .OrderByExpressions(sortExpressions)
                    .Skip(skip)
                    .Take(take)
                    .ToListAsync(cancellationToken);
            }

            return result;
        }

        public static IQueryable<TEntity> AddIncludes<TEntity, TKey>(this IQueryable<TEntity> entities, IEnumerable<string> includePaths)
            where TEntity : class, IEntity<TKey>
        {
            if (includePaths?.Any() != true)
            {
                return entities;
            }

            // using special overload of include that takes string
            // https://docs.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.entityframeworkqueryableextensions.include?view=efcore-3.1
            return includePaths.Aggregate(entities,
                (current, includePath) => current.Include(includePath));
        }
    }
}
