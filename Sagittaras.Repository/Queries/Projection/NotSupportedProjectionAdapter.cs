using System;
using System.Linq;

namespace Sagittaras.Repository.Queries.Projection;

/// <summary>
///     An implementation of <see cref="IProjectionAdapter" /> that does not support entity projection.
/// </summary>
/// <remarks>
///     This adapter throws a <see cref="NotSupportedException" /> if attempted to perform projection,
///     encouraging users to provide custom implementations for specific entity projections.
/// </remarks>
public class NotSupportedProjectionAdapter : IProjectionAdapter
{
    /// <inheritdoc />
    public IQueryable<TDestination> ProjectTo<TDestination>(IQueryable queryable)
    {
        throw new NotSupportedException($"For entities projection create custom implementation of {nameof(IProjectionAdapter)}");
    }
}