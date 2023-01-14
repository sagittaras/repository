using System.Linq;
using Sagittaras.Repository.Queries;

namespace Sagittaras.Repository.Test.Mapping.Environment.Repository
{
    public class GetUserById : IQuery<User>
    {
        public int Id { get; }

        public GetUserById(int id)
        {
            Id = id;
        }
        
        public IQueryable<User> Execute(IQueryable<User> queryable)
        {
            return queryable.Where(u => u.Id == Id);
        }
    }
}