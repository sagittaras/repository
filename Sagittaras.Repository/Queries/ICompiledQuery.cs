using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Sagittaras.Repository.Queries;

/// <summary>
///     Describes a query object with usage of Compiled Queries.
/// </summary>
public interface ICompiledQuery<out TEntity> where TEntity : class
{
    /// <summary>
    ///     Converts the compiled query results to an asynchronous enumerable sequence.
    /// </summary>
    /// <param name="context">The database context to execute the query on.</param>
    /// <returns>An IAsyncEnumerable sequence that contains the results of the query.</returns>
    IAsyncEnumerable<TEntity> ToAsyncEnumerable(DbContext context);
}