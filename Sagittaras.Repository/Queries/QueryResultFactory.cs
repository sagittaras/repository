using System.Linq;
using Sagittaras.Repository.Queries.Find;
using Sagittaras.Repository.Queries.Get;
using Sagittaras.Repository.Queries.Projection;

namespace Sagittaras.Repository.Queries
{
    /// <summary>
    /// Default factory implementation for creating a query results.
    /// </summary>
    public class QueryResultFactory(IProjectionAdapter projectionAdapter) : IQueryResultFactory
    {
        /// <inheritdoc />
        public IGetQueryResult<TEntity> CreateGetResult<TEntity>(IQueryable<TEntity> queryable) where TEntity : class
        {
            return new GetQueryResult<TEntity>(queryable, projectionAdapter);
        }

        /// <inheritdoc />
        public IFindQueryResult<TEntity> CreateFindResult<TEntity>(IQueryable<TEntity> queryable) where TEntity : class
        {
            return new FindQueryResult<TEntity>(queryable, projectionAdapter);
        }

        public IQueryResult<TEntity> CreateQueryResult<TEntity>(IQueryable<TEntity> queryable) where TEntity : class
        {
            return new QueryResult<TEntity>(queryable);
        }
    }
}