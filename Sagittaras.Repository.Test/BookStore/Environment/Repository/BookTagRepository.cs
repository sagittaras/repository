using System;
using Microsoft.EntityFrameworkCore;
using Sagittaras.Repository.Queries;

namespace Sagittaras.Repository.Test.BookStore.Environment.Repository
{
    public class BookTagRepository : Repository<BookTag, Guid, int>
    {
        public BookTagRepository(DbContext dbContext, IQueryResultFactory queryResultFactory) : base(dbContext, queryResultFactory)
        {
        }
    }
}