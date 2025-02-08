using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Sagittaras.Repository.Operations
{
    /// <summary>
    /// Operation removing set of entities from database.
    /// </summary>
    /// <typeparam name="TEntity">Type of used entities.</typeparam>
    public class RemoveRangeOperation<TEntity>(DbContext context, IEnumerable<TEntity> entities) : IRepositoryOperation where TEntity : class
    {
        /// <inheritdoc />
        public void Apply()
        {
            context.RemoveRange(entities);
        }
    }
}