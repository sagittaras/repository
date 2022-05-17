using System;
using Microsoft.EntityFrameworkCore;

namespace Sagittaras.Repository.Test.BookStore.Environment.Repository
{
    public class BookRepository : Repository<Book, Guid>
    {
        public BookRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}