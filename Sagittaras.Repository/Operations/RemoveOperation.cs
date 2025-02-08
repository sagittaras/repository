using Microsoft.EntityFrameworkCore;

namespace Sagittaras.Repository.Operations;

/// <summary>
///     Operation removing entity from database.
/// </summary>
/// <typeparam name="TEntity">Type of used entity.</typeparam>
public class RemoveOperation<TEntity>(DbContext context, TEntity entity) : IRepositoryOperation where TEntity : class
{
    /// <inheritdoc />
    public void Apply()
    {
        context.Remove(entity);
    }
}