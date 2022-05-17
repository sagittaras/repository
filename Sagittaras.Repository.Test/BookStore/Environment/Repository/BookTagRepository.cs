using System;
using Microsoft.EntityFrameworkCore;

namespace Sagittaras.Repository.Test.BookStore.Environment.Repository
{
    public class BookTagRepository : Repository<BookTag, Guid, int>
    {
        public BookTagRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}