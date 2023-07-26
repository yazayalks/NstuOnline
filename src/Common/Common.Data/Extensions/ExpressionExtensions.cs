using System;
using System.Linq.Expressions;
using Common.Data.Visitors;

namespace Common.Data.Extensions;

public static class ExpressionExtensions
{
    public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> expr1,
        Expression<Func<T, bool>> expr2)
    {
        return Expression.Lambda<Func<T, bool>>(
            Expression.OrElse(
                new SwapVisitor(expr1.Parameters[0], expr2.Parameters[0]).Visit(expr1.Body),
                expr2.Body
            ), expr2.Parameters);
    }
}