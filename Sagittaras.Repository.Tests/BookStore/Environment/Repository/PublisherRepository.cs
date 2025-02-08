using System;
using Microsoft.EntityFrameworkCore;
using Sagittaras.Repository.Queries;

namespace Sagittaras.Repository.Tests.BookStore.Environment.Repository
{
    public class PublisherRepository(DbContext dbContext, IQueryResultFactory queryResultFactory) : Repository<Publisher, Guid>(dbContext, queryResultFactory);
}