using System.Threading.Tasks;

namespace Sagittaras.Repository.Queries;

/// <summary>
///     General interface providing a common method for any kind of query result.
/// </summary>
/// <typeparam name="TEntity"></typeparam>
public interface IQueryResult<TEntity> where TEntity : class
{
    /// <summary>
    ///     Determines whether any element matches the query.
    /// </summary>
    /// <returns></returns>
    bool Any();

    /// <summary>
    ///     Determines whether any element matches the query asynchronously.
    /// </summary>
    /// <returns></returns>
    Task<bool> AnyAsync();

    /// <summary>
    ///     Counts the number of elements in the query.
    /// </summary>
    /// <returns></returns>
    int Count();

    /// <summary>
    ///     Counts the number of elements in the query asynchronously.
    /// </summary>
    /// <returns></returns>
    Task<int> CountAsync();
}