using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Sagittaras.Repository.Queries.Get
{
    /// <summary>
    /// Default implementation of the Query result.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class GetQueryResult<TEntity> : IGetQueryResult<TEntity> where TEntity : class
    {
        private readonly IQueryable<TEntity> _queryable;

        public GetQueryResult(IQueryable<TEntity> queryable)
        {
            _queryable = queryable;
        }

        /// <inheritdoc />
        public TEntity Single()
        {
            return _queryable.Single();
        }

        /// <inheritdoc />
        public async Task<TEntity> SingleAsync()
        {
            return await _queryable.SingleAsync();
        }

        /// <inheritdoc />
        public TEntity First()
        {
            return _queryable.First();
        }

        /// <inheritdoc />
        public async Task<TEntity> FirstAsync()
        {
            return await _queryable.FirstAsync();
        }

        /// <inheritdoc />
        public TDto GetProjected<TDto>()
        {
            throw new NotSupportedException($"For DTO projection create a custom implementation of {nameof(IGetQueryResult<object>)} or extends {nameof(GetQueryResult<object>)}");
        }

        /// <inheritdoc />
        public Task<TDto> GetProjectedAsync<TDto>()
        {
            throw new NotSupportedException($"For DTO projection create a custom implementation of {nameof(IGetQueryResult<object>)} or extends {nameof(GetQueryResult<object>)}");
        }
    }
}