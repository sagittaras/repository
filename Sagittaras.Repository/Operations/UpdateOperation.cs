using Microsoft.EntityFrameworkCore;

namespace Sagittaras.Repository.Operations
{
    /// <summary>
    /// Operation updating an entity in database.
    /// </summary>
    /// <typeparam name="TEntity">Type of used entity.</typeparam>
    public class UpdateOperation<TEntity> : IRepositoryOperation where TEntity : class
    {
        private readonly DbContext _context;
        private readonly TEntity _entity;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="entity"></param>
        public UpdateOperation(DbContext context, TEntity entity)
        {
            _context = context;
            _entity = entity;
        }

        /// <inheritdoc />
        public void Apply()
        {
            _context.Update(_entity);
        }
    }
}