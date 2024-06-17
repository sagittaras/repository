using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Sagittaras.Repository.Operations;
using Sagittaras.Repository.Queries;
using Sagittaras.Repository.Queries.Find;
using Sagittaras.Repository.Queries.Get;

namespace Sagittaras.Repository
{
    /// <summary>
    /// Internal implementation of repository.
    /// </summary>
    /// <remarks>
    /// Repository without its generic type is useless.
    /// </remarks>
    public abstract class Repository : IRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="entityType"></param>
        protected Repository(DbContext dbContext, Type entityType)
        {
            Context = dbContext;
            ClrType = entityType;
            EntityType = dbContext.Model.FindEntityType(entityType) ?? throw new ArgumentException("Entity type not found in the context.");
        }

        /// <inheritdoc />
        public IEntityType EntityType { get; }

        /// <inheritdoc />
        public Type ClrType { get; }

        /// <inheritdoc />
        public bool HasChanges => Operations.Count > 0;

        /// <inheritdoc />
        public abstract bool HasData { get; }

        /// <inheritdoc />
        public abstract bool IsEmpty { get; }

        /// <summary>
        /// Protected access to the context of database the repository is working with.
        /// </summary>
        internal DbContext Context { get; }

        /// <summary>
        /// Queue of operations which should be executed the repository is saving changes.
        /// </summary>
        internal Queue<IRepositoryOperation> Operations { get; } = new();

        /// <inheritdoc />
        public void SaveChanges()
        {
            SaveChangesAsync().GetAwaiter().GetResult();
        }

        /// <inheritdoc />
        public async Task SaveChangesAsync()
        {
            while (Operations.TryDequeue(out IRepositoryOperation? operation))
            {
                operation.Apply();
            }

            await Context.SaveChangesAsync();
        }

        /// <inheritdoc />
        public abstract Task<bool> HasDataAsync();

        /// <inheritdoc />
        public abstract Task<bool> IsEmptyAsync();
    }

    /// <summary>
    /// Generic implementation of repository.
    /// </summary>
    /// <typeparam name="TEntity">Target type of entity the repository is working with.</typeparam>
    public abstract class Repository<TEntity> : Repository, IRepository<TEntity> where TEntity : class
    {
        private readonly IQueryResultFactory _queryResultFactory;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="queryResultFactory"></param>
        protected Repository(DbContext dbContext, IQueryResultFactory queryResultFactory) : base(dbContext, typeof(TEntity))
        {
            _queryResultFactory = queryResultFactory;
            Table = dbContext.Set<TEntity>();
            Queryable = Table.AsQueryable();
        }

        /// <inheritdoc />
        public override bool HasData => Table.Any();

        /// <inheritdoc />
        public override bool IsEmpty => !HasData;

        /// <summary>
        /// Original <see cref="DbSet{TEntity}"/> for entity.
        /// </summary>
        public DbSet<TEntity> Table { get; }

        /// <summary>
        /// Queryable data source of <see cref="Table"/>
        /// </summary>
        protected IQueryable<TEntity> Queryable { get; }

        /// <inheritdoc />
        public override async Task<bool> HasDataAsync()
        {
            return await Table.AnyAsync();
        }

        /// <inheritdoc />
        public override async Task<bool> IsEmptyAsync()
        {
            return !await Table.AnyAsync();
        }

        /// <inheritdoc />
        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await Queryable.ToListAsync();
        }

        /// <inheritdoc />
        public void Insert(TEntity entity)
        {
            Operations.Enqueue(new InsertOperation<TEntity>(Context, entity));
        }

        /// <inheritdoc />
        public void InsertRange(IEnumerable<TEntity> entities)
        {
            Operations.Enqueue(new InsertRangeOperation<TEntity>(Context, entities));
        }

        /// <inheritdoc />
        public void Update(TEntity entity)
        {
            Operations.Enqueue(new UpdateOperation<TEntity>(Context, entity));
        }

        /// <inheritdoc />
        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            Operations.Enqueue(new UpdateRangeOperation<TEntity>(Context, entities));
        }

        /// <inheritdoc />
        public void Remove(TEntity entity)
        {
            Operations.Enqueue(new RemoveOperation<TEntity>(Context, entity));
        }

        /// <inheritdoc />
        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            Operations.Enqueue(new RemoveRangeOperation<TEntity>(Context, entities));
        }

        /// <inheritdoc />
        public async Task<TEntity?> Get(params object?[]? keyValues)
        {
            return await Table.FindAsync(keyValues).AsTask();
        }

        /// <inheritdoc />
        public IGetQueryResult<TEntity> Get(IQuery<TEntity> query)
        {
            return _queryResultFactory.CreateGetResult(query.Execute(Queryable));
        }

        /// <inheritdoc />
        public IFindQueryResult<TEntity> Find(IQuery<TEntity> query)
        {
            return _queryResultFactory.CreateFindResult(query.Execute(Queryable));
        }

        /// <summary>
        /// Finds a <see cref="DbSet{TEntity}"/> for the target entity type.
        /// </summary>
        /// <typeparam name="TAnotherEntity">Target entity type.</typeparam>
        /// <returns>DbSet of the target entity.</returns>
        protected DbSet<TAnotherEntity> Join<TAnotherEntity>() where TAnotherEntity : class
        {
            return Context.Set<TAnotherEntity>();
        }
    }

    /// <summary>
    /// Generic implementation of Repository controlling the data type of primary key.
    /// </summary>
    /// <typeparam name="TEntity">The type of entity.</typeparam>
    /// <typeparam name="TKey">The type of primary key of entity.</typeparam>
    public abstract class Repository<TEntity, TKey> : Repository<TEntity>, IRepository<TEntity, TKey> where TEntity : class
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="queryResultFactory"></param>
        protected Repository(DbContext dbContext, IQueryResultFactory queryResultFactory) : base(dbContext, queryResultFactory)
        {
        }
        
        /// <inheritdoc />
        public async Task<TEntity?> Get(TKey id)
        {
            return await Table.FindAsync(id).AsTask();
        }
    }

    /// <summary>
    /// Repository supporting identification via composite PK.
    /// </summary>
    /// <typeparam name="TEntity">Data type of used entity</typeparam>
    /// <typeparam name="TFirstKey">Data type of first part of PK</typeparam>
    /// <typeparam name="TSecondKey">Data type of second part of PK</typeparam>
    public abstract class Repository<TEntity, TFirstKey, TSecondKey> : Repository<TEntity, TFirstKey>, IRepository<TEntity, TFirstKey, TSecondKey> where TEntity : class
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="queryResultFactory"></param>
        protected Repository(DbContext dbContext, IQueryResultFactory queryResultFactory) : base(dbContext, queryResultFactory)
        {
        }

        /// <inheritdoc />
        public async Task<TEntity?> Get(TFirstKey firstKey, TSecondKey secondKey)
        {
            return await Table.FindAsync(firstKey, secondKey).AsTask();
        }
    }
}