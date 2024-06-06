using System.Collections;
using System.Collections.Generic;

namespace Sagittaras.Repository.Queries.Find.Pagination;

/// <summary>
///     Collection describing the result of a paginated query.
/// </summary>
/// <typeparam name="TData">Type of data in collection.</typeparam>
public class PagedCollection<TData> : IPagedCollection<TData>
{
    /// <inheritdoc />
    public int Total { get; set; }

    /// <inheritdoc />
    public int Limit { get; set; }

    /// <inheritdoc />
    public int Offset { get; set; }
    
    /// <inheritdoc />
    public ICollection<TData> Data { get; set; } = new List<TData>();
        
    /// <inheritdoc />
    public int Count => Data.Count;

    /// <inheritdoc />
    public IEnumerator<object> GetEnumerator()
    {
        return (IEnumerator<object>) Data.GetEnumerator();
    }

    /// <inheritdoc />
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}