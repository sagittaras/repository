using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Sagittaras.Repository.Queries.Projection;

namespace Sagittaras.Repository.Test.Mapping.Environment.Projection
{
    /// <summary>
    ///     Adapter class that integrates AutoMapper support for queryable projections
    ///     and implements the IProjectionAdapter interface.
    /// </summary>
    public class AutoMapperAdapter(IMapper mapper) : IProjectionAdapter
    {
        /// <inheritdoc />
        public IQueryable<TDestination> ProjectTo<TDestination>(IQueryable queryable)
        {
            return queryable.ProjectTo<TDestination>(mapper.ConfigurationProvider);
        }
    }
}