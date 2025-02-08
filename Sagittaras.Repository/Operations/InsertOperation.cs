using Microsoft.EntityFrameworkCore;

namespace Sagittaras.Repository.Operations
{
    /// <summary>
    /// Represents an insert operation.
    /// </summary>
    public class InsertOperation<TEntity>(DbContext dbContext, TEntity entity) : IRepositoryOperation where TEntity : class
    {
        /// <inheritdoc />
        public void Apply()
        {
            dbContext.Add(entity);
        }
    }
}