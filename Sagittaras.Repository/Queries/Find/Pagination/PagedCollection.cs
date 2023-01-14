using System.Collections;
using System.Collections.Generic;

namespace Sagittaras.Repository.Queries.Find.Pagination
{
    /// <summary>
    /// Collection describing the result of a paginated query.
    /// </summary>
    /// <typeparam name="TData">Type of data in collection.</typeparam>
    public class PagedCollection<TData> : IEnumerable<TData>
    {
        /// <summary>
        /// Total data count in the dataset.
        /// </summary>
        public int Total { get; set; }
        
        /// <summary>
        /// How many items are in the current page.
        /// </summary>
        public int Limit { get; set; }
        
        /// <summary>
        /// How many items are skipped from the beginning of the dataset.
        /// </summary>
        public int Offset { get; set; }
        
        /// <summary>
        /// Enumerable of data in the current page.
        /// </summary>
        public IEnumerable<TData> Data { get; set; } = new List<TData>();

        /// <inheritdoc />
        public IEnumerator<TData> GetEnumerator()
        {
            return Data.GetEnumerator();
        }

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}