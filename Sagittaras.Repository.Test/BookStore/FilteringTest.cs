using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Sagittaras.Repository.Queries.Find.Filtering;
using Sagittaras.Repository.Test.BookStore.Environment;
using Sagittaras.Repository.Test.BookStore.Environment.Queries;
using Sagittaras.Repository.Test.BookStore.Environment.Repository;
using Sagittaras.Repository.Test.BookStore.Environment.SetUp;
using Xunit;
using Xunit.Abstractions;

namespace Sagittaras.Repository.Test.BookStore
{
    public class FilteringTest : BookStoreTest
    {
        private readonly AuthorRepository _authorRepository;
        
        public FilteringTest(BookStoreFactory factory, ITestOutputHelper testOutputHelper) : base(factory, testOutputHelper)
        {
            _authorRepository = ServiceProvider.GetRequiredService<AuthorRepository>();
        }

        [Fact]
        public async Task Test_EqualFilter()
        {
            _authorRepository.InsertRange(new List<Author>
            {
                new(){Name = "Alfred", Email = "alfred@author.com"},
                new(){Name = "Bob", Email = "bob@author.com"},
                new(){Name = "Cindy", Email = "cindy@author.com"}
            });
            await _authorRepository.SaveChangesAsync();

            FilterQuery query = new()
            {
                Filters =
                {
                    new PropertyFilter { PropertyName = "Name", Value = "Bob" }
                }
            };

            IList<Author> authors = (await _authorRepository.Find(new FindAuthors()).FindFilteredAsync(query)).ToList();
            authors.Should().HaveCount(1);
            authors.Should().ContainSingle(a => a.Name == "Bob");
            authors.Should().ContainSingle(a => a.Email == "bob@author.com");
        }

        [Fact]
        public async Task Test_NotEqualFilter()
        {
            _authorRepository.InsertRange(new List<Author>
            {
                new(){Name = "Alfred", Email = "alfred@author.com"},
                new(){Name = "Bob", Email = "bob@author.com"},
                new(){Name = "Cindy", Email = "cindy@author.com"}
            });
            await _authorRepository.SaveChangesAsync();

            FilterQuery query = new()
            {
                Filters =
                {
                    new PropertyFilter { PropertyName = "Name", Value = "Bob", ComparisonType = ComparisonType.NotEqual}
                }
            };

            IList<Author> authors = (await _authorRepository.Find(new FindAuthors()).FindFilteredAsync(query)).ToList();
            authors.Should().HaveCount(3); // There is initial insert of one author.
            authors.Should().NotContain(x => x.Name == "Bob");
        }

        [Fact]
        public async Task Test_ContainsFilter()
        {
            _authorRepository.InsertRange(new List<Author>
            {
                new(){Name = "Bob Small", Email = "bob.small@author.com"},
                new(){Name = "Bob Big", Email = "bob.big@author.com"},
                new(){Name = "Cindy", Email = "cindy@author.com"}
            });
            await _authorRepository.SaveChangesAsync();

            FilterQuery query = new()
            {
                Filters =
                {
                    new PropertyFilter { PropertyName = "Name", Value = "bob", ComparisonType = ComparisonType.Contains}
                }
            };

            IList<Author> authors = (await _authorRepository.Find(new FindAuthors()).FindFilteredAsync(query)).ToList();
            authors.Should().HaveCount(2);
            authors.Should().NotContain(x => x.Name == "Cindy");
        }

        [Fact]
        public async Task Test_NotContainsFilter()
        {
            _authorRepository.InsertRange(new List<Author>
            {
                new(){Name = "Bob Small", Email = "bob.small@author.com"},
                new(){Name = "Bob Big", Email = "bob.big@author.com"},
                new(){Name = "Cindy", Email = "cindy@author.com"}
            });
            await _authorRepository.SaveChangesAsync();

            FilterQuery query = new()
            {
                Filters =
                {
                    new PropertyFilter { PropertyName = "Name", Value = "Bob", ComparisonType = ComparisonType.NotContains}
                }
            };

            IList<Author> authors = (await _authorRepository.Find(new FindAuthors()).FindFilteredAsync(query)).ToList();
            authors.Should().HaveCount(2); // There is already one inserted at initial seed
            authors.Should().NotContain(x => x.Name.Contains("Bob"));
        }
    }
}