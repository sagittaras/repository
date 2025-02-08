using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Sagittaras.Repository.Queries.Find.Pagination
{
    public static class QueryableExtension
    {
        /// <summary>
        ///     Applies pagination to the given queryable based on the provided pagination parameters and returns a paginated collection of data.
        /// </summary>
        /// <typeparam name="TData">The type of the data in the queryable and the paginated result.</typeparam>
        /// <param name="queryable">The queryable to which pagination will be applied.</param>
        /// <param name="query">The pagination query object containing limit and offset values.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains a <see cref="PagedCollection{TData}"/> with the paginated data, total count, limit, and offset.</returns>
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