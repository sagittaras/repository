using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sagittaras.Repository.Queries.Find.Filtering;
using Sagittaras.Repository.Queries.Find.Filtering.Extensions;
using Sagittaras.Repository.Queries.Find.Pagination;
using Sagittaras.Repository.Queries.Projection;

namespace Sagittaras.Repository.Queries.Find
{
    /// <summary>
    /// Default implementation of the query result.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class FindQueryResult<TEntity> : IFindQueryResult<TEntity> where TEntity : class
    {
        private readonly IQueryable<TEntity> _queryable;
        private readonly IProjectionAdapter _projectionAdapter;

        public FindQueryResult(IQueryable<TEntity> queryable, IProjectionAdapter projectionAdapter)
        {
            _queryable = queryable;
            _projectionAdapter = projectionAdapter;
        }

        /// <inheritdoc />
        public IEnumerable<TEntity> Find()
        {
            return _queryable.ToList();
        }

        /// <inheritdoc />
        public async Task<IEnumerable<TEntity>> FindAsync()
        {
            return await _queryable.ToListAsync();
        }

        /// <inheritdoc />
        public async Task<PagedCollection<TEntity>> FindPagedAsync(PaginationQuery query)
        {
            return await _queryable.ApplyPaginationAsync(query);
        }

        /// <inheritdoc />
        public async Task<IEnumerable<TEntity>> FindFilteredAsync(FilterQuery filterQuery)
        {
            return await _queryable
                .ApplyFilter(filterQuery)
                .ToListAsync();
        }

        /// <inheritdoc />
        public IEnumerable<TDto> FindProjected<TDto>()
        {
            return _projectionAdapter
                .ProjectTo<TDto>(_queryable)
                .ToList();
        }

        /// <inheritdoc />
        public async Task<IEnumerable<TDto>> FindProjectedAsync<TDto>()
        {
            return await _projectionAdapter
                .ProjectTo<TDto>(_queryable)
                .ToListAsync();
        }

        /// <inheritdoc />
        public async Task<PagedCollection<TDto>> FindProjectedAndPaginatedAsync<TDto>(PaginationQuery query)
        {
            return await _projectionAdapter
                .ProjectTo<TDto>(_queryable)
                .ApplyPaginationAsync(query);
        }
    }
}