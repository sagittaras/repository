using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sagittaras.Repository.Queries;

/// <summary>
///     Provides an implementation for querying results from an asynchronous enumerable source.
/// </summary>
/// <typeparam name="TEntity">The type of the entity.</typeparam>
public class CompiledQueryResult<TEntity> : IQueryResult<TEntity> where TEntity : class
{
    protected readonly IAsyncEnumerable<TEntity> AsyncEnumerable;

    public CompiledQueryResult(IAsyncEnumerable<TEntity> asyncEnumerable)
    {
        AsyncEnumerable = asyncEnumerable;
    }

    /// <inheritdoc />
    public bool Any()
    {
        return AnyAsync()
            .GetAwaiter()
            .GetResult();
    }

    /// <inheritdoc />
    public Task<bool> AnyAsync()
    {
        return AsyncEnumerable.AnyAsync().AsTask();
    }

    /// <inheritdoc />
    public int Count()
    {
        return CountAsync()
            .GetAwaiter()
            .GetResult();
    }

    /// <inheritdoc />
    public Task<int> CountAsync()
    {
        return AsyncEnumerable.CountAsync().AsTask();
    }
}