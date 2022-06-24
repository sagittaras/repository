using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sagittaras.Repository.Queries.Find
{
    public interface IFindQueryResult<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> Find();

        Task<IEnumerable<TEntity>> FindAsync();

        IEnumerable<TDto> FindProjected<TDto>();

        Task<IEnumerable<TDto>> FindProjectedAsync<TDto>();
    }
}