using System.Linq;

namespace Sagittaras.Repository.Queries.Find.Filtering.Extensions
{
    public static class QueryableExtension
    {
        /// <summary>
        /// Extension method applying filtering to IQueryable.
        /// </summary>
        /// <param name="queryable">The queryable source to which the filtering is applied.</param>
        /// <param name="query">URL query describing how to filter query.</param>
        /// <typeparam name="TData">Type of entity on which the filter is applied.</typeparam>
        /// <returns></returns>
        public static IQueryable<TData> ApplyFilter<TData>(this IQueryable<TData> queryable, FilterQuery query)
        {
            return queryable.Where(new ExpressionBuilder(query).Build<TData>());
        }
    }
}