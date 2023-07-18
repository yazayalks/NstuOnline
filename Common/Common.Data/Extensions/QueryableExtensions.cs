using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Common.Models;

namespace Common.Data.Extensions
{
    public static class QueryableExtensions
    {
        public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> source, string property)
        {
            return ApplyOrder(source, property, "OrderBy");
        }

        public static IOrderedQueryable<T> OrderByDescending<T>(this IQueryable<T> source, string property)
        {
            return ApplyOrder(source, property, "OrderByDescending");
        }

        public static IOrderedQueryable<T> ThenBy<T>(this IOrderedQueryable<T> source, string property)
        {
            return ApplyOrder(source, property, "ThenBy");
        }

        public static IOrderedQueryable<T> ThenByDescending<T>(this IOrderedQueryable<T> source, string property)
        {
            return ApplyOrder(source, property, "ThenByDescending");
        }

        public static IOrderedQueryable<T> OrderByExpressions<T>(this IQueryable<T> query, IList<SortExpression> sortExpressions) where T : class
        {
            if (sortExpressions == null || !sortExpressions.Any())
            {
                return (IOrderedQueryable<T>)query;
            }

            var firstSortField = sortExpressions.First();

            var orderedQuery = firstSortField.Direction == SortDirection.Desc
                ? query.OrderByDescending(firstSortField.PropertyName)
                : query.OrderBy(firstSortField.PropertyName);

            foreach (var sortExpression in sortExpressions.Skip(1).ToArray())
            {
                orderedQuery = sortExpression.Direction == SortDirection.Desc
                    ? orderedQuery.ThenByDescending(sortExpression.PropertyName)
                    : orderedQuery.ThenBy(sortExpression.PropertyName);
            }

            return orderedQuery;
        }

        public static IQueryable<T> WithPaging<T>(this IQueryable<T> query,
            IList<SortExpression> sortExpressions, int skip, int take) where T : class
        {
            return query.OrderByExpressions(sortExpressions).Skip(skip).Take(take);
        }

        // TODO: refactor this method
        private static IOrderedQueryable<T> ApplyOrder<T>(IQueryable<T> source, string property, string methodName)
        {
            if (property == null)
            {
                throw new ArgumentNullException(nameof(property));
            }

            var properties = property.Split('.');

            var type = source.ElementType;
            var argument = Expression.Parameter(type, "x");
            var expression = (Expression)argument;

            foreach (var prop in properties)
            {
                // use reflection (not ComponentModel) to mirror LINQ
                var propertyInfo = type.GetProperty(prop, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                if (propertyInfo != null)
                {
                    expression = Expression.Property(expression, propertyInfo);
                    type = propertyInfo.PropertyType;
                }
                else
                {
                    return (IOrderedQueryable<T>)source; 
                }
            }

            var delegateType = typeof(Func<,>).MakeGenericType(typeof(T), type);
            var lambda = Expression.Lambda(delegateType, expression, argument);

            var result = typeof(Queryable).GetMethods().Single(
                    method => method.Name == methodName
                              && method.IsGenericMethodDefinition
                              && method.GetGenericArguments().Length == 2
                              && method.GetParameters().Length == 2)
                .MakeGenericMethod(typeof(T), type)
                .Invoke(null, new object[] { source, lambda });

            return (IOrderedQueryable<T>)result!;
        }
    }
}
