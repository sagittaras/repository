using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Sagittaras.Repository.Queries.Find.Filtering
{
    /// <summary>
    /// URL query used to filter results of the DB query.
    /// </summary>
    public class FilterQuery : IEnumerable<PropertyFilter>
    {
        /// <summary>
        /// List of property filters to be applied.
        /// </summary>
        public List<PropertyFilter> Filters { get; } = new();

        /// <summary>
        /// The epxression to be used to filter the query.
        /// </summary>
        public ExpressionType ExpressionType { get; set; } = ExpressionType.AndAlso;

        /// <inheritdoc />
        public IEnumerator<PropertyFilter> GetEnumerator()
        {
            return Filters.GetEnumerator();
        }

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}