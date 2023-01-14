using Microsoft.EntityFrameworkCore;
using Sagittaras.Repository.Queries;

namespace Sagittaras.Repository.Test.BookStore.Environment.Repository
{
    public class TagRepository : Repository<Tag, int>
    {
        public TagRepository(DbContext dbContext, IQueryResultFactory queryResultFactory) : base(dbContext, queryResultFactory)
        {
        }
    }
}