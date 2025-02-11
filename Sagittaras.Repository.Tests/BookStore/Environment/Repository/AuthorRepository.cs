using System;
using Microsoft.EntityFrameworkCore;
using Sagittaras.Repository.Queries;

namespace Sagittaras.Repository.Tests.BookStore.Environment.Repository;

public class AuthorRepository(DbContext dbContext, IQueryResultFactory queryResultFactory) : Repository<Author, Guid>(dbContext, queryResultFactory), IAuthorRepository;