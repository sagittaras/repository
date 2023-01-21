using System;
using System.Linq.Expressions;
using Sagittaras.Repository.Queries.Find.Filtering.Extensions;

namespace Sagittaras.Repository.Queries.Find.Filtering
{
    /// <summary>
    /// Builds the Lambda expression for the query filtering.
    /// </summary>
    public class ExpressionBuilder
    {
        /// <summary>
        /// The query used for filtering.
        /// </summary>
        private readonly FilterQuery _query;

        public ExpressionBuilder(FilterQuery query)
        {
            _query = query;
        }
        
        /// <summary>
        /// Builds the Lambda expression for the query filtering.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public Expression<Func<T, bool>> Build<T>()
        {
            if (_query.Filters.Count == 0)
            {
                return x => true;
            }

            ParameterExpression parameterExpression = Expression.Parameter(typeof(T), "x");
            Expression? expression = default;

            foreach (PropertyFilter filter in _query.Filters)
            {
                Expression propertyExpression = Expression.Property(parameterExpression, filter.PropertyName);
                Expression valueExpression = Expression.Constant(filter.Value);
                Expression comparisonExpression = BuildComparison(propertyExpression, valueExpression, filter.ComparisonType);

                if (expression == null)
                {
                    expression = comparisonExpression;
                }
                else
                {
                    expression = Expression.MakeBinary(_query.ExpressionType, expression, comparisonExpression);
                }
            }

            if (expression is null)
            {
                return x => true;
            }

            return Expression.Lambda<Func<T, bool>>(expression, parameterExpression);
        }

        /// <summary>
        /// Gets the comparison expression.
        /// </summary>
        /// <param name="left">Left side of the comparison.</param>
        /// <param name="right">Right side of the comparison.</param>
        /// <param name="comparisonType">Operator applied to comparisson.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">Unknown type of comparison type.</exception>
        private static Expression BuildComparison(Expression left, Expression right, ComparisonType comparisonType)
        {
            return comparisonType switch
            {
                ComparisonType.Equals => Expression.Equal(left, right),
                ComparisonType.NotEqual => Expression.NotEqual(left, right),
                ComparisonType.Contains => Expression.Call(left.NormalizeIfString(), StringMethodAccessor.Contains, right.NormalizeIfString()),
                ComparisonType.NotContains => Expression.Not(Expression.Call(left.NormalizeIfString(), StringMethodAccessor.Contains, right.NormalizeIfString())),
                _ => throw new ArgumentOutOfRangeException(nameof(comparisonType), comparisonType, null)
            };
        }
    }
}