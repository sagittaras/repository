using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Sagittaras.Repository.Operations
{
    /// <summary>
    /// Operation inserting a range of entities.
    /// </summary>
    /// <typeparam name="TEntity">Used entity.</typeparam>
    public class InsertRangeOperation<TEntity> : IRepositoryOperation where TEntity : class
    {
        private readonly DbContext _context;
        private readonly IEnumerable<TEntity> _entities;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="entities"></param>
        public InsertRangeOperation(DbContext context, IEnumerable<TEntity> entities)
        {
            _context = context;
            _entities = entities;
        }

        /// <inheritdoc />
        public void Apply()
        {
            _context.AddRange(_entities);
        }
    }
}