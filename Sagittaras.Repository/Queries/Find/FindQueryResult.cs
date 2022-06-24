using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Sagittaras.Repository.Queries.Find
{
    /// <summary>
    /// Default implementation of the query result.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class FindQueryResult<TEntity> : IFindQueryResult<TEntity> where TEntity : class
    {
        private readonly IQueryable<TEntity> _queryable;

        public FindQueryResult(IQueryable<TEntity> queryable)
        {
            _queryable = queryable;
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
        public IEnumerable<TDto> FindProjected<TDto>()
        {
            throw new NotSupportedException($"For DTO projection create a custom implementation of {nameof(IFindQueryResult<object>)} or extends {nameof(FindQueryResult<object>)}");
        }

        /// <inheritdoc />
        public Task<IEnumerable<TDto>> FindProjectedAsync<TDto>()
        {
            throw new NotSupportedException($"For DTO projection create a custom implementation of {nameof(IFindQueryResult<object>)} or extends {nameof(FindQueryResult<object>)}");
        }
    }
}