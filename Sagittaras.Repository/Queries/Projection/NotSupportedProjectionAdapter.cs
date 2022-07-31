using System;
using System.Linq;

namespace Sagittaras.Repository.Queries.Projection
{
    /// <summary>
    /// Default implementation of projection adapter without support.
    /// </summary>
    public class NotSupportedProjectionAdapter : IProjectionAdapter
    {
        public IQueryable<TDestination> ProjectTo<TDestination>(IQueryable queryable)
        {
            throw new NotSupportedException($"For entities projection create custom implementation of {nameof(IProjectionAdapter)}");
        }
    }
}