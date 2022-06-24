using System.Linq;
using Sagittaras.Repository.Queries;

namespace Sagittaras.Repository.Test.BookStore.Environment.Queries
{
    public class AllTagsQuery : IQuery<Tag>
    {
        public IQueryable<Tag> Execute(IQueryable<Tag> queryable)
        {
            return queryable.OrderByDescending(t => t.Id);
        }
    }
}