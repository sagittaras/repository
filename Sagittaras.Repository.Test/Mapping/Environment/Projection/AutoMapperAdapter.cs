using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Sagittaras.Repository.Queries.Projection;

namespace Sagittaras.Repository.Test.Mapping.Environment.Projection
{
    public class AutoMapperAdapter : IProjectionAdapter
    {
        private readonly IMapper _mapper;

        public AutoMapperAdapter(IMapper mapper)
        {
            _mapper = mapper;
        }
        
        public IQueryable<TDestination> ProjectTo<TDestination>(IQueryable queryable)
        {
            return queryable.ProjectTo<TDestination>(_mapper.ConfigurationProvider);
        }
    }
}