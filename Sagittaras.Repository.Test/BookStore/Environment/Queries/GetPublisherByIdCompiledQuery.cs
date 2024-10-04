using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Sagittaras.Repository.Queries;

namespace Sagittaras.Repository.Test.BookStore.Environment.Queries;

/// <summary>
///     Represents a compiled query for retrieving a publisher by its unique identifier.
/// </summary>
public class GetPublisherByIdCompiledQuery : ICompiledQuery<Publisher>
{
    /// <summary>
    ///     Represents the compiled query function that takes a database context and a publisher identifier,
    ///     and returns an asynchronous enumerable of publishers matching the given identifier.
    /// </summary>
    private static readonly Func<DbContext, Guid, IAsyncEnumerable<Publisher>> Query = EF.CompileAsyncQuery(
        (DbContext context, Guid id) => context.Set<Publisher>().Where(x => x.Id == id)
    );

    /// <summary>
    ///     Stores the unique identifier of the publisher for the query.
    /// </summary>
    private readonly Guid _id;

    public GetPublisherByIdCompiledQuery(Guid id)
    {
        _id = id;
    }

    /// <inheritdoc />
    public IAsyncEnumerable<Publisher> ToAsyncEnumerable(DbContext context)
    {
        return Query.Invoke(context, _id);
    }
}