using System;
using Microsoft.EntityFrameworkCore;
using Sagittaras.Repository.Queries;

namespace Sagittaras.Repository.Tests.BookStore.Environment.Repository
{
    public class BookTagRepository(DbContext dbContext, IQueryResultFactory queryResultFactory) : Repository<BookTag, Guid, int>(dbContext, queryResultFactory);
}