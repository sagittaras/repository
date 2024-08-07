﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Sagittaras.Repository.Queries.Find.Pagination;

namespace Sagittaras.Repository.Queries.Find
{
    public interface IFindQueryResult<TEntity> : IQueryResult<TEntity> where TEntity : class
    {
        /// <summary>
        /// Find the collection of selected entities.
        /// </summary>
        /// <returns></returns>
        ICollection<TEntity> Find();

        /// <summary>
        /// Find the collection of selected entities asynchronously.
        /// </summary>
        /// <returns></returns>
        Task<ICollection<TEntity>> FindAsync();
        
        /// <summary>
        /// Find the collection of selected entities with pagination.
        /// </summary>
        /// <param name="query">Pagination URL query data.</param>
        /// <returns></returns>
        Task<PagedCollection<TEntity>> FindPagedAsync(PaginationQuery query);

        /// <summary>
        /// Find the collection of selected entities projected to DTO object.
        /// </summary>
        /// <typeparam name="TDto"></typeparam>
        /// <returns></returns>
        ICollection<TDto> FindProjected<TDto>();

        /// <summary>
        /// Find the collection of selected entities projected to DTO object asynchronously.
        /// </summary>
        /// <typeparam name="TDto"></typeparam>
        /// <returns></returns>
        Task<ICollection<TDto>> FindProjectedAsync<TDto>();
        
        /// <summary>
        /// Find the collection of selected entities projected to DTO object with pagination.
        /// </summary>
        /// <param name="query"></param>
        /// <typeparam name="TDto"></typeparam>
        /// <returns></returns>
        Task<PagedCollection<TDto>> FindProjectedAndPaginatedAsync<TDto>(PaginationQuery query);
    }
}