using Microsoft.EntityFrameworkCore;

namespace Sagittaras.Repository.Operations;

/// <summary>
///     Operation updating an entity in database.
/// </summary>
/// <typeparam name="TEntity">Type of used entity.</typeparam>
public class UpdateOperation<TEntity>(DbContext context, TEntity entity) : IRepositoryOperation where TEntity : class
{
    /// <inheritdoc />
    public void Apply()
    {
        context.Update(entity);
    }
}