using System.Linq;
using Sagittaras.Repository.Queries;

namespace Sagittaras.Repository.Test.BookStore.Environment.Queries
{
    public class FindAuthors : IQuery<Author>
    {
        public IQueryable<Author> Execute(IQueryable<Author> queryable)
        {
            return queryable;
        }
    }
}