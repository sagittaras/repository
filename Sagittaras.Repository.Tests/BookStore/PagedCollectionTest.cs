using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Sagittaras.Repository.Queries.Find.Pagination;
using Sagittaras.Repository.Tests.BookStore.Environment;
using Xunit;

namespace Sagittaras.Repository.Tests.BookStore
{
    public class PagedCollectionTest
    {
        [Fact]
        public void Test_IsOfType()
        {
            PagedCollection<Author> collection = new()
            {
                Data = new List<Author>
                {
                    new(){Name = "Author #1"},
                    new(){Name = "Author #2"},
                    new(){Name = "Author #3"},
                    new(){Name = "Author #4"},
                    new(){Name = "Author #5"},
                }
            };
            collection.Should().BeAssignableTo<IPagedCollection>();
            collection.Should().BeAssignableTo<IPagedCollection<Author>>();
            
            // ReSharper disable once ConvertTypeCheckToNullCheck
            bool isPagedCollection = collection is IPagedCollection;
            isPagedCollection.Should().BeTrue();

            collection.Should().HaveCount(5);
            collection.First().Should().BeAssignableTo<Author>();
            collection.OfType<Author>().First().Name.Should().Be("Author #1");
        }
    }
}