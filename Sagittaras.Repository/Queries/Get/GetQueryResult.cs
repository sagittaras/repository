using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sagittaras.Repository.Queries.Projection;

namespace Sagittaras.Repository.Queries.Get;

/// <summary>
///     Default implementation of the Query result.
/// </summary>
/// <typeparam name="TEntity"></typeparam>
public class GetQueryResult<TEntity>(IQueryable<TEntity> queryable, IProjectionAdapter projectionAdapter) : QueryResult<TEntity>(queryable), IGetQueryResult<TEntity>
    where TEntity : class
{
    private readonly IQueryable<TEntity> _queryable = queryable;

    /// <inheritdoc />
    public TEntity Single()
    {
        return _queryable.Single();
    }

    /// <inheritdoc />
    public async Task<TEntity> SingleAsync()
    {
        return await _queryable.SingleAsync();
    }

    /// <inheritdoc />
    public TEntity First()
    {
        return _queryable.First();
    }

    /// <inheritdoc />
    public async Task<TEntity> FirstAsync()
    {
        return await _queryable.FirstAsync();
    }

    /// <inheritdoc />
    public TDto SingleProjected<TDto>()
    {
        return projectionAdapter.ProjectTo<TDto>(_queryable).Single();
    }

    /// <inheritdoc />
    public async Task<TDto> SingleProjectedAsync<TDto>()
    {
        return await projectionAdapter.ProjectTo<TDto>(_queryable).SingleAsync();
    }

    /// <inheritdoc />
    public TDto FirstProjected<TDto>()
    {
        return projectionAdapter.ProjectTo<TDto>(_queryable).First();
    }

    /// <inheritdoc />
    public async Task<TDto> FirstProjectAsync<TDto>()
    {
        return await projectionAdapter.ProjectTo<TDto>(_queryable).FirstAsync();
    }
}