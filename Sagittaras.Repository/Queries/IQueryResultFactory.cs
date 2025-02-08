using System.Linq;
using Sagittaras.Repository.Queries.Find;
using Sagittaras.Repository.Queries.Get;

namespace Sagittaras.Repository.Queries;

/// <summary>
///     Defines a factory used to create a new prepared result instances of the query.
/// </summary>
public interface IQueryResultFactory
{
    /// <summary>
    ///     Creates a new prepared result instance of the query for Get operations.
    /// </summary>
    /// <typeparam name="TEntity">The type of entity used in the query.</typeparam>
    /// <param name="queryable">The queryable object representing the source data.</param>
    /// <returns>An <see cref="IGetQueryResult{TEntity}" /> instance that allows further query result manipulation for Get operations.</returns>
    IGetQueryResult<TEntity> CreateGetResult<TEntity>(IQueryable<TEntity> queryable) where TEntity : class;

    /// <summary>
    ///     Creates a new prepared result instance of the query for Find operations.
    /// </summary>
    /// <typeparam name="TEntity">The type of entity used in the query.</typeparam>
    /// <param name="queryable">The queryable object representing the source data.</param>
    /// <returns>An <see cref="IFindQueryResult{TEntity}" /> instance that allows further query result manipulation for Find operations.</returns>
    IFindQueryResult<TEntity> CreateFindResult<TEntity>(IQueryable<TEntity> queryable) where TEntity : class;

    /// <summary>
    ///     Creates a new prepared result instance of the query.
    /// </summary>
    /// <typeparam name="TEntity">The type of entity used in the query.</typeparam>
    /// <param name="queryable">The queryable object representing the source data.</param>
    /// <returns>An <see cref="IQueryResult{TEntity}" /> instance that allows further query result manipulation.</returns>
    IQueryResult<TEntity> CreateQueryResult<TEntity>(IQueryable<TEntity> queryable) where TEntity : class;
}