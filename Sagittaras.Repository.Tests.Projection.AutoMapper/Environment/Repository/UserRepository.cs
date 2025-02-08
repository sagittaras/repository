using Microsoft.EntityFrameworkCore;
using Sagittaras.Repository.Queries;

namespace Sagittaras.Repository.Tests.Projection.AutoMapper.Environment.Repository;

public class UserRepository(DbContext dbContext, IQueryResultFactory queryResultFactory) : Repository<User, int>(dbContext, queryResultFactory);