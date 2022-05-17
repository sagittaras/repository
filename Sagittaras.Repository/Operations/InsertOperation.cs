using Microsoft.EntityFrameworkCore;

namespace Sagittaras.Repository.Operations
{
    /// <summary>
    /// Represents an insert operation.
    /// </summary>
    public class InsertOperation<TEntity> : IRepositoryOperation where TEntity : class
    {
        private readonly DbContext _dbContext;
        private readonly TEntity _entity;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbContext">Accessed context by repository.</param>
        /// <param name="entity">Entity to be saved.</param>
        public InsertOperation(DbContext dbContext, TEntity entity)
        {
            _dbContext = dbContext;
            _entity = entity;
        }
        
        /// <inheritdoc />
        public void Apply()
        {
            _dbContext.Add(_entity);
        }
    }
}