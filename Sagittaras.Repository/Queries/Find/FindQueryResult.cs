using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sagittaras.Repository.Queries.Find.Pagination;
using Sagittaras.Repository.Queries.Projection;

namespace Sagittaras.Repository.Queries.Find
{
    /// <summary>
    ///     Represents the result of a query operation for a specific entity type.
    /// </summary>
    /// <remarks>
    ///     Provides methods for finding, projecting, and paginating query results,
    ///     either synchronously or asynchronously.
    /// </remarks>
    /// <typeparam name="TEntity">The type of the entity being queried.</typeparam>
    public class FindQueryResult<TEntity>(IQueryable<TEntity> queryable, IProjectionAdapter projectionAdapter) : QueryResult<TEntity>(queryable), IFindQueryResult<TEntity>
        where TEntity : class
    {
        private readonly IQueryable<TEntity> _queryable = queryable;

        /// <inheritdoc />
        public ICollection<TEntity> Find()
        {
            return _queryable.ToList();
        }

        /// <inheritdoc />
        public async Task<ICollection<TEntity>> FindAsync()
        {
            return await _queryable.ToListAsync();
        }

        /// <inheritdoc />
        public async Task<PagedCollection<TEntity>> FindPagedAsync(PaginationQuery query)
        {
            return await _queryable.ApplyPaginationAsync(query);
        }

        /// <inheritdoc />
        public ICollection<TDto> FindProjected<TDto>()
        {
            return projectionAdapter
                .ProjectTo<TDto>(_queryable)
                .ToList();
        }

        /// <inheritdoc />
        public async Task<ICollection<TDto>> FindProjectedAsync<TDto>()
        {
            return await projectionAdapter
                .ProjectTo<TDto>(_queryable)
                .ToListAsync();
        }

        /// <inheritdoc />
        public async Task<PagedCollection<TDto>> FindProjectedAndPaginatedAsync<TDto>(PaginationQuery query)
        {
            return await projectionAdapter
                .ProjectTo<TDto>(_queryable)
                .ApplyPaginationAsync(query);
        }
    }
}