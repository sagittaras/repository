using System.Linq;
using Sagittaras.Repository.Queries.Find;
using Sagittaras.Repository.Queries.Get;

namespace Sagittaras.Repository.Queries
{
    /// <summary>
    /// Defines a factory used to create a new prepared result instances of the query.
    /// </summary>
    public interface IQueryResultFactory
    {
        IGetQueryResult<TEntity> CreateGetResult<TEntity>(IQueryable<TEntity> queryable) where TEntity : class;

        IFindQueryResult<TEntity> CreateFindResult<TEntity>(IQueryable<TEntity> queryable) where TEntity : class;
    }
}