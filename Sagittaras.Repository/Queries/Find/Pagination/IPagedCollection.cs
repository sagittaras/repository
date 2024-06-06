using System.Collections.Generic;

namespace Sagittaras.Repository.Queries.Find.Pagination;

public interface IPagedCollection : IReadOnlyCollection<object>
{
    /// <summary>
    /// Total data count in the dataset.
    /// </summary>
    int Total { get; set; }
        
    /// <summary>
    /// How many items are in the current page.
    /// </summary>
    int Limit { get; set; }
        
    /// <summary>
    /// How many items are skipped from the beginning of the dataset.
    /// </summary>
    int Offset { get; set; }
}