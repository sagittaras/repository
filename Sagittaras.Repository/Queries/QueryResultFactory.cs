using System.Collections.Generic;
using System.Linq;
using Sagittaras.Repository.Queries.Find;
using Sagittaras.Repository.Queries.Get;
using Sagittaras.Repository.Queries.Projection;

namespace Sagittaras.Repository.Queries
{
    /// <summary>
    /// Default factory implementation for creating a query results.
    /// </summary>
    public class QueryResultFactory : IQueryResultFactory
    {
        private readonly IProjectionAdapter _projectionAdapter;

        public QueryResultFactory(IProjectionAdapter projectionAdapter)
        {
            _projectionAdapter = projectionAdapter;
        }

        /// <inheritdoc />
        public IGetQueryResult<TEntity> CreateGetResult<TEntity>(IQueryable<TEntity> queryable) where TEntity : class
        {
            return new GetQueryResult<TEntity>(queryable, _projectionAdapter);
        }

        /// <inheritdoc />
        public IGetQueryResult<TEntity> CreateGetResult<TEntity>(IAsyncEnumerable<TEntity> asyncEnumerable) where TEntity : class
        {
            return new GetCompiledQueryResult<TEntity>(asyncEnumerable);
        }

        /// <inheritdoc />
        public IFindQueryResult<TEntity> CreateFindResult<TEntity>(IQueryable<TEntity> queryable) where TEntity : class
        {
            return new FindQueryResult<TEntity>(queryable, _projectionAdapter);
        }

        public IFindQueryResult<TEntity> CreateFindResult<TEntity>(IAsyncEnumerable<TEntity> asyncEnumerable) where TEntity : class
        {
            throw new System.NotImplementedException();
        }

        public IQueryResult<TEntity> CreateQueryResult<TEntity>(IQueryable<TEntity> queryable) where TEntity : class
        {
            return new QueryResult<TEntity>(queryable);
        }

        public IQueryResult<TEntity> CreateQueryResult<TEntity>(IAsyncEnumerable<TEntity> asyncEnumerable) where TEntity : class
        {
            throw new System.NotImplementedException();
        }
    }
}