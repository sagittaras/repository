using System.Linq.Expressions;

namespace Sagittaras.Repository.Queries.Find.Filtering.Extensions
{
    internal static class ExpressionExtension
    {
        /// <summary>
        /// Normalizes the member for comparison is it is a string type.
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        internal static Expression NormalizeIfString(this Expression expression)
        {
            if (expression.Type != typeof(string))
            {
                return expression;
            }
            
            Expression trimmed = Expression.Call(expression, StringMethodAccessor.Trim);
            return Expression.Call(trimmed, StringMethodAccessor.ToUpper);
        }
    }
}