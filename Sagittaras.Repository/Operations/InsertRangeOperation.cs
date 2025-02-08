using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Sagittaras.Repository.Operations;

/// <summary>
///     Operation inserting a range of entities.
/// </summary>
/// <typeparam name="TEntity">Used entity.</typeparam>
public class InsertRangeOperation<TEntity>(DbContext context, IEnumerable<TEntity> entities) : IRepositoryOperation where TEntity : class
{
    /// <inheritdoc />
    public void Apply()
    {
        context.AddRange(entities);
    }
}