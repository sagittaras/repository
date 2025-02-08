using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Sagittaras.Repository.Queries;

/// <summary>
///     General Query result for a queryable.
/// </summary>
/// <remarks>
///     This query result can check if there are any results and count the results,
///     that are expected by the queryable.
/// </remarks>
/// <typeparam name="TEntity"></typeparam>
public class QueryResult<TEntity>(IQueryable<TEntity> queryable) : IQueryResult<TEntity>
    where TEntity : class
{
    /// <inheritdoc />
    public bool Any()
    {
        return queryable.Any();
    }

    /// <inheritdoc />
    public Task<bool> AnyAsync()
    {
        return queryable.AnyAsync();
    }

    /// <inheritdoc />
    public int Count()
    {
        return queryable.Count();
    }

    /// <inheritdoc />
    public Task<int> CountAsync()
    {
        return queryable.CountAsync();
    }
}