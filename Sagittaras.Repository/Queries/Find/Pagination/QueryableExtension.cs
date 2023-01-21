using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Sagittaras.Repository.Queries.Find.Pagination
{
    public static class QueryableExtension
    {
        /// <summary>
        /// Extension method applying pagination to IQueryable.
        /// </summary>
        /// <param name="queryable">The queryable source to which the pagination is applied.</param>
        /// <param name="query">URL query describing the pagination.</param>
        /// <typeparam name="TData">Type of selected entity.</typeparam>
        /// <returns></returns>
        public static async Task<PagedCollection<TData>> ApplyPaginationAsync<TData>(this IQueryable<TData> queryable, PaginationQuery query)
        {
            return new PagedCollection<TData>
            {
                Limit = query.Limit,
                Offset = query.Offset,
                Total = await queryable.CountAsync(),
                Data = await queryable.Skip(query.Offset).Take(query.Limit).ToListAsync()
            };
        }
    }
}