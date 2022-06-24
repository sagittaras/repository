using System.Linq;
using Sagittaras.Repository.Queries.Find;
using Sagittaras.Repository.Queries.Get;

namespace Sagittaras.Repository.Queries
{
    /// <summary>
    /// Default factory implementation for creating a query results.
    /// </summary>
    public class QueryResultFactory : IQueryResultFactory
    {
        /// <inheritdoc />
        public IGetQueryResult<TEntity> CreateGetResult<TEntity>(IQueryable<TEntity> queryable) where TEntity : class
        {
            return new GetQueryResult<TEntity>(queryable);
        }

        /// <inheritdoc />
        public IFindQueryResult<TEntity> CreateFindResult<TEntity>(IQueryable<TEntity> queryable) where TEntity : class
        {
            return new FindQueryResult<TEntity>(queryable);
        }
    }
}