using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Sagittaras.Repository.Operations
{
    /// <summary>
    /// Operation removing set of entities from database.
    /// </summary>
    /// <typeparam name="TEntity">Type of used entities.</typeparam>
    public class RemoveRangeOperation<TEntity> : IRepositoryOperation where TEntity : class
    {
        private readonly DbContext _context;
        private readonly IEnumerable<TEntity> _entities;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="entities"></param>
        public RemoveRangeOperation(DbContext context, IEnumerable<TEntity> entities)
        {
            _context = context;
            _entities = entities;
        }

        /// <inheritdoc />
        public void Apply()
        {
            _context.RemoveRange(_entities);
        }
    }
}