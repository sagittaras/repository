using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Sagittaras.Repository.Queries.Projection;

namespace Sagittaras.Repository.Queries;

/// <summary>
///     Represents a compiled query that projects the result to a specified entity type.
/// </summary>
/// <typeparam name="TDto">The type of the DTO to which the query results are projected.</typeparam>
public interface IProjectedCompiledQuery<out TDto>
{
    /// <summary>
    ///     Converts the query result to an asynchronous enumerable stream of the projected entity type.
    /// </summary>
    /// <param name="dbContext">The database context used to execute the query.</param>
    /// <param name="projectionAdapter">The projection adapter used to map the query result to the entity type.</param>
    /// <returns>An asynchronous enumerable containing the query results projected to the specified entity type.</returns>
    IAsyncEnumerable<TDto> ToAsyncEnumerable(DbContext dbContext, IProjectionAdapter projectionAdapter);
}