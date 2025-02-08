using Microsoft.EntityFrameworkCore;
using Sagittaras.Repository.Queries;

namespace Sagittaras.Repository.Test.BookStore.Environment.Repository
{
    public class TagRepository(DbContext dbContext, IQueryResultFactory queryResultFactory) : Repository<Tag, int>(dbContext, queryResultFactory);
}