using AutoMapper;
using AutoMapper.QueryableExtensions;
using Sagittaras.Repository.Queries.Projection;

namespace Sagittaras.Repository.Projection.AutoMapper;

/// <summary>
///     Adapts a queryable source using AutoMapper to project its elements to a specified type.
/// </summary>
public class AutoMapperProjectionAdapter(IMapper mapper) : IProjectionAdapter
{
    /// <inheritdoc />
    public IQueryable<TResult> ProjectTo<TResult>(IQueryable queryable)
    {
        return queryable.ProjectTo<TResult>(mapper.ConfigurationProvider);
    }
}