using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sagittaras.Repository.Queries.Projection;

namespace Sagittaras.Repository.Queries.Get
{
    /// <summary>
    /// Default implementation of the Query result.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class GetQueryResult<TEntity> : QueryResult<TEntity>, IGetQueryResult<TEntity> where TEntity : class
    {
        private readonly IQueryable<TEntity> _queryable;
        private readonly IProjectionAdapter _projectionAdapter;

        public GetQueryResult(IQueryable<TEntity> queryable, IProjectionAdapter projectionAdapter) : base(queryable)
        {
            _queryable = queryable;
            _projectionAdapter = projectionAdapter;
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
        public TDto SingleProjected<TDto>()
        {
            return _projectionAdapter.ProjectTo<TDto>(_queryable).Single();
        }

        /// <inheritdoc />
        public async Task<TDto> SingleProjectedAsync<TDto>()
        {
            return await _projectionAdapter.ProjectTo<TDto>(_queryable).SingleAsync();
        }

        /// <inheritdoc />
        public TDto FirstProjected<TDto>()
        {
            return _projectionAdapter.ProjectTo<TDto>(_queryable).First();
        }

        /// <inheritdoc />
        public async Task<TDto> FirstProjectedAsync<TDto>()
        {
            return await _projectionAdapter.ProjectTo<TDto>(_queryable).FirstAsync();
        }
    }
}