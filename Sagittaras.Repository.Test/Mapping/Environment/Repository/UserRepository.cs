using Microsoft.EntityFrameworkCore;
using Sagittaras.Repository.Queries;

namespace Sagittaras.Repository.Test.Mapping.Environment.Repository
{
    public class UserRepository : Repository<User, int>
    {
        public UserRepository(DbContext dbContext, IQueryResultFactory queryResultFactory) : base(dbContext, queryResultFactory)
        {
        }
    }
}