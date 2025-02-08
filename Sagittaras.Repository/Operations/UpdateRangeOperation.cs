using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Sagittaras.Repository.Operations;

/// <summary>
///     Operation updating a range of entities in database.
/// </summary>
/// <typeparam name="TEntity">Type of used entity.</typeparam>
public class UpdateRangeOperation<TEntity>(DbContext context, IEnumerable<TEntity> entities) : IRepositoryOperation where TEntity : class
{
    /// <inheritdoc />
    public void Apply()
    {
        context.UpdateRange(entities);
    }
}