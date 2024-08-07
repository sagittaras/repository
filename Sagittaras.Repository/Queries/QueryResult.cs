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
public class QueryResult<TEntity> : IQueryResult<TEntity> where TEntity : class
{
    private readonly IQueryable<TEntity> _queryable;

    public QueryResult(IQueryable<TEntity> queryable)
    {
        _queryable = queryable;
    }

    /// <inheritdoc />
    public bool Any()
    {
        return _queryable.Any();
    }

    /// <inheritdoc />
    public Task<bool> AnyAsync()
    {
        return _queryable.AnyAsync();
    }

    /// <inheritdoc />
    public int Count()
    {
        return _queryable.Count();
    }

    /// <inheritdoc />
    public Task<int> CountAsync()
    {
        return _queryable.CountAsync();
    }
}