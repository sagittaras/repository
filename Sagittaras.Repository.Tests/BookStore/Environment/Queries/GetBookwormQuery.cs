using System;
using System.Linq;
using Sagittaras.Repository.Queries;

namespace Sagittaras.Repository.Tests.BookStore.Environment.Queries;

public class GetBookwormQuery : IQuery<Author>
{
    public IQueryable<Author> Execute(IQueryable<Author> queryable)
    {
        return queryable.Where(a => a.Id.Equals(Guid.Parse("6e7c8428-6b49-4c94-b062-af832efd7236")));
    }
}