using System.Threading.Tasks;

namespace Sagittaras.Repository.Queries.Get
{
    /// <summary>
    /// Represents a prepared resultset for a Get Query.
    /// </summary>
    /// <typeparam name="TEntity">Type of used query.</typeparam>
    public interface IGetQueryResult<TEntity> : IQueryResult<TEntity> where TEntity : class
    {
        /// <summary>
        /// Gets the single entity.
        /// </summary>
        /// <returns></returns>
        TEntity Single();
        
        /// <summary>
        /// Gets the single entity as asynchronous task.
        /// </summary>
        /// <returns></returns>
        Task<TEntity> SingleAsync();

        /// <summary>
        /// Gets the first entity in the query.
        /// </summary>
        /// <returns></returns>
        TEntity First();

        /// <summary>
        /// Gets the first entity in the query async.
        /// </summary>
        /// <returns></returns>
        Task<TEntity> FirstAsync();

        /// <summary>
        /// Gets the single entity projected to DTO.
        /// </summary>
        /// <typeparam name="TDto">Type of final object.</typeparam>
        /// <returns></returns>
        TDto SingleProjected<TDto>();

        /// <summary>
        /// Gets the single entity projected to DTO as asynchronous task.
        /// </summary>
        /// <typeparam name="TDto">Type of final object.</typeparam>
        /// <returns></returns>
        Task<TDto> SingleProjectedAsync<TDto>();

        /// <summary>
        /// Gets the first entity projected as DTO.
        /// </summary>
        /// <typeparam name="TDto"></typeparam>
        /// <returns></returns>
        TDto FirstProjected<TDto>();

        /// <summary>
        /// Gets the first entity projected to DTO as async task.
        /// </summary>
        /// <typeparam name="TDto"></typeparam>
        /// <returns></returns>
        Task<TDto> FirstProjectedAsync<TDto>();
    }
}