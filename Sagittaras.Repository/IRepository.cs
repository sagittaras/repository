using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Sagittaras.Repository.Queries;
using Sagittaras.Repository.Queries.Find;
using Sagittaras.Repository.Queries.Get;

namespace Sagittaras.Repository
{
    /// <summary>
    /// Basic non-geric repository definition.
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// EF Core entity type describing the entity used with this repository.
        /// </summary>
        IEntityType EntityType { get; }
        
        /// <summary>
        /// The CLR type of entity used with this repository.
        /// </summary>
        Type ClrType { get; }

        /// <summary>
        /// Gets whether this repository has unsaved changes.
        /// </summary>
        bool HasChanges { get; }
        
        /// <summary>
        /// Gets whether this repository has data in database.
        /// </summary>
        bool HasData { get; }
        
        /// <summary>
        /// Gets whether this repository has empty table in database.
        /// </summary>
        bool IsEmpty { get; }

        /// <summary>
        /// Saves all changes made to this repository.
        /// </summary>
        /// <returns>How many rows was saved to the database from this repository.</returns>
        void SaveChanges();

        /// <summary>
        /// Saves all changes made to this repository as async task.
        /// </summary>
        /// <returns>How many rows was saved to the database from this repository.</returns>
        Task SaveChangesAsync();

        /// <summary>
        /// Checks if repository has data as async Task.
        /// </summary>
        /// <returns>True if there are data in database.</returns>
        Task<bool> HasDataAsync();

        /// <summary>
        /// Checks if repository is empty as async task.
        /// </summary>
        /// <returns>True if there are no data in database.</returns>
        Task<bool> IsEmptyAsync();
    }

    /// <summary>
    /// Generic repository controlling the type of used entity.
    /// </summary>
    /// <typeparam name="TEntity">The data of entity used with repository.</typeparam>
    public interface IRepository<TEntity> : IRepository where TEntity : class
    {
        /// <summary>
        /// Access to the DbSet of repository for entity.
        /// </summary>
        DbSet<TEntity> Table { get; }
        
        /// <summary>
        /// Gets all entities in this repository.
        /// </summary>
        /// <returns>An enumerable of all entites.</returns>
        Task<IEnumerable<TEntity>> GetAll();

        /// <summary>
        /// Inserts a new record to the repository.
        /// </summary>
        /// <param name="entity">Entity to be saved list.</param>
        void Insert(TEntity entity);

        /// <summary>
        /// Inserts a new range of entites to the repisitory.
        /// </summary>
        /// <param name="entities">Enumerable of entities to be saved.</param>
        void InsertRange(IEnumerable<TEntity> entities);

        /// <summary>
        /// Updates a entity in repository.
        /// </summary>
        /// <param name="entity">Entity to be updated.</param>
        void Update(TEntity entity);

        /// <summary>
        /// Updates a range of entites.
        /// </summary>
        /// <param name="entities">Enumerable of entities to be updated.</param>
        void UpdateRange(IEnumerable<TEntity> entities);

        /// <summary>
        /// Removes an entity from repository.
        /// </summary>
        /// <param name="entity">Entity to be removed.</param>
        void Remove(TEntity entity);

        /// <summary>
        /// Removes a range of entities from repository.
        /// </summary>
        /// <param name="entities">Enumerable of netities to be removed.</param>
        void RemoveRange(IEnumerable<TEntity> entities);

        /// <summary>
        /// Gets the entity by the value of it's primary key.
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        Task<TEntity?> Get(params object?[]? keyValues);

        /// <summary>
        /// Prepares a single entity result set from the query object.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        IGetQueryResult<TEntity> Get(IQuery<TEntity> query);

        /// <summary>
        /// Prepares a collection entity result set from the query object.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        IFindQueryResult<TEntity> Find(IQuery<TEntity> query);
    }

    /// <summary>
    /// Generic repository expanding posibilities of query by the generic type of primary key.
    /// </summary>
    /// <typeparam name="TEntity">The datatype of saved entity.</typeparam>
    /// <typeparam name="TKey">The datatype of primary key on entity.</typeparam>
    public interface IRepository<TEntity, in TKey> : IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Gets an entity by the primary key value.
        /// </summary>
        /// <param name="id">Value of primary key.</param>
        /// <returns>Awaitable task resulting in entity or null if not found.</returns>
        Task<TEntity?> Get(TKey id);
    }

    /// <summary>
    /// Repository supporting composite key identification.
    /// </summary>
    /// <typeparam name="TEntity">The type of used entity.</typeparam>
    /// <typeparam name="TFirstKey">The type of first part of primary key.</typeparam>
    /// <typeparam name="TSecondKey">The type of second part of primary key.</typeparam>
    public interface IRepository<TEntity, in TFirstKey, in TSecondKey> : IRepository<TEntity, TFirstKey> where TEntity : class
    {
        /// <summary>
        /// Gets the entity by the both primary key types.
        /// </summary>
        /// <param name="firstKey">Value of first part of PK.</param>
        /// <param name="secondKey">Value of second part of PK.</param>
        /// <returns>Entity if found or null.</returns>
        Task<TEntity?> Get(TFirstKey firstKey, TSecondKey secondKey);
    }
}