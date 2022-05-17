using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Sagittaras.Repository.Operations
{
    /// <summary>
    /// Operation updating a range of entities in database.
    /// </summary>
    /// <typeparam name="TEntity">Type of used entity.</typeparam>
    public class UpdateRangeOperation<TEntity> : IRepositoryOperation where TEntity : class
    {
        private readonly DbContext _context;
        private readonly IEnumerable<TEntity> _entities;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="entities"></param>
        public UpdateRangeOperation(DbContext context, IEnumerable<TEntity> entities)
        {
            _context = context;
            _entities = entities;
        }

        /// <inheritdoc />
        public void Apply()
        {
            _context.UpdateRange(_entities);
        }
    }
}