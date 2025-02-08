using System.Linq;

namespace Sagittaras.Repository.Queries.Projection;

/// <summary>
///     Provides functionality to adapt a queryable source for projecting its elements to a different type.
/// </summary>
public interface IProjectionAdapter
{
    /// <summary>
    ///     Projects the elements of a queryable source to a different type.
    /// </summary>
    /// <typeparam name="TResult">The target type to which elements are projected.</typeparam>
    /// <param name="queryable">The queryable data source to be projected.</param>
    /// <returns>A queryable of the target type containing the projected elements.</returns>
    IQueryable<TResult> ProjectTo<TResult>(IQueryable queryable);
}