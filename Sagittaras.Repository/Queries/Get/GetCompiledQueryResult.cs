using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sagittaras.Repository.Queries.Get;

/// <summary>
///     Represents a compiled query result, providing methods to retrieve single or first entities from an asynchronous enumerable source,
///     with optional projection support for transforming entities into different data transfer objects.
/// </summary>
/// <typeparam name="TEntity">The type of the entity.</typeparam>
public class GetCompiledQueryResult<TEntity> : CompiledQueryResult<TEntity>, IGetQueryResult<TEntity> where TEntity : class
{
    public GetCompiledQueryResult(IAsyncEnumerable<TEntity> asyncEnumerable) : base(asyncEnumerable)
    {
    }

    /// <inheritdoc />
    public TEntity Single()
    {
        return SingleAsync()
            .GetAwaiter()
            .GetResult();
    }

    public Task<TEntity> SingleAsync()
    {
        return AsyncEnumerable.SingleAsync().AsTask();
    }

    /// <inheritdoc />
    public TEntity First()
    {
        return FirstAsync()
            .GetAwaiter()
            .GetResult();
    }

    public Task<TEntity> FirstAsync()
    {
        return AsyncEnumerable.FirstAsync().AsTask();
    }

    /// <inheritdoc />
    public TDto SingleProjected<TDto>()
    {
        return SingleProjectedAsync<TDto>()
            .GetAwaiter()
            .GetResult();
    }

    public Task<TDto> SingleProjectedAsync<TDto>()
    {
        throw new NotSupportedException($"For projection of compiled queries use {nameof(IProjectedCompiledQuery<TDto>)} interface to create a projected query.");
    }

    /// <inheritdoc />
    public TDto FirstProjected<TDto>()
    {
        return FirstProjectedAsync<TDto>()
            .GetAwaiter()
            .GetResult();

    }

    public Task<TDto> FirstProjectedAsync<TDto>()
    {
        throw new NotSupportedException($"For projection of compiled queries use {nameof(IProjectedCompiledQuery<TDto>)} interface to create a projected query.");
    }
}