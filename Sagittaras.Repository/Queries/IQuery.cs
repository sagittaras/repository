using System.Linq;

namespace Sagittaras.Repository.Queries;

/// <summary>
///     Definition of a single query to be executed
/// </summary>
/// <typeparam name="TEntity">Type of entity bound to query.</typeparam>
public interface IQuery<TEntity> where TEntity : class
{
    /// <summary>
    ///     Alternates the queryable datasource of entity by the query.
    /// </summary>
    /// <param name="queryable">Raw queryable datasource.</param>
    /// <returns>Alternated queryable instance.</returns>
    IQueryable<TEntity> Execute(IQueryable<TEntity> queryable);
}