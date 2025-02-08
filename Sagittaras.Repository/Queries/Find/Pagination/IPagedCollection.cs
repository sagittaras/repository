using System.Collections.Generic;

namespace Sagittaras.Repository.Queries.Find.Pagination;

/// <summary>
///     Interface for a collection describing the result of a paginated query.
/// </summary>
public interface IPagedCollection : IReadOnlyCollection<object>
{
    /// <summary>
    ///     Total data count in the dataset.
    /// </summary>
    int Total { get; set; }

    /// <summary>
    ///     How many items are in the current page.
    /// </summary>
    int Limit { get; set; }

    /// <summary>
    ///     How many items are skipped from the beginning of the dataset.
    /// </summary>
    int Offset { get; set; }
}

/// <summary>
///     Represents a collection that supports pagination functionality and describes the result of a query.
/// </summary>
public interface IPagedCollection<TData> : IPagedCollection
{
    /// <summary>
    ///     Collection of data in the current page.
    /// </summary>
    ICollection<TData> Data { get; set; }
}