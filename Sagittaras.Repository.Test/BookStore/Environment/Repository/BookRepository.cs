using System;
using Microsoft.EntityFrameworkCore;
using Sagittaras.Repository.Queries;

namespace Sagittaras.Repository.Test.BookStore.Environment.Repository
{
    public class BookRepository : Repository<Book, Guid>
    {
        public BookRepository(DbContext dbContext, IQueryResultFactory queryResultFactory) : base(dbContext, queryResultFactory)
        {
        }
    }
}