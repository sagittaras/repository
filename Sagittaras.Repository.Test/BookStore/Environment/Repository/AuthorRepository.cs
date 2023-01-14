using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sagittaras.Repository.Queries;

namespace Sagittaras.Repository.Test.BookStore.Environment.Repository
{
    public class AuthorRepository : Repository<Author, Guid>
    {
        public AuthorRepository(DbContext dbContext, IQueryResultFactory queryResultFactory) : base(dbContext, queryResultFactory)
        {
        }
        
        public Task<Author> GetByEmail(string email)
        {
            return Queryable.SingleOrDefaultAsync(a => a.Email == email);
        }

        public Task<int> CountAuthors()
        {
            return Queryable.CountAsync();
        }
    }
}