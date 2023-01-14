using System.Linq;

namespace Sagittaras.Repository.Queries.Projection
{
    public interface IProjectionAdapter
    {
        /// <summary>
        /// Projects the queryable to target destionation.
        /// </summary>
        /// <typeparam name="TDestination">The target destination to which the queryable should be projected.</typeparam>
        /// <returns></returns>
        IQueryable<TDestination> ProjectTo<TDestination>(IQueryable queryable);
    }
}