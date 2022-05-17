using System;
using Microsoft.EntityFrameworkCore;

namespace Sagittaras.Repository.Test.BookStore.Environment.Repository
{
    public class PublisherRepository : Repository<Publisher, Guid>
    {
        public PublisherRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}