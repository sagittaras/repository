using System;
using Microsoft.EntityFrameworkCore;
using Sagittaras.Repository.Queries;

namespace Sagittaras.Repository.Tests.BookStore.Environment.Repository
{
    public class BookRepository(DbContext dbContext, IQueryResultFactory queryResultFactory) : Repository<Book, Guid>(dbContext, queryResultFactory);
}