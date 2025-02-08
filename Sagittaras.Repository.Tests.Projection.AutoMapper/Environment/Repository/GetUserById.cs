using Sagittaras.Repository.Queries;

namespace Sagittaras.Repository.Tests.Projection.AutoMapper.Environment.Repository
{
    public class GetUserById(int id) : IQuery<User>
    {
        public int Id { get; } = id;

        public IQueryable<User> Execute(IQueryable<User> queryable)
        {
            return queryable.Where(u => u.Id == Id);
        }
    }
}