using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Sagittaras.Repository.Queries.Find.Pagination;
using Sagittaras.Repository.Tests.BookStore.Environment;
using Sagittaras.Repository.Tests.BookStore.Environment.Queries;
using Sagittaras.Repository.Tests.BookStore.Environment.Repository;
using Sagittaras.Repository.Tests.BookStore.Environment.SetUp;
using Xunit;
using Xunit.Abstractions;

namespace Sagittaras.Repository.Tests.BookStore
{
    public class RepositoryTest : BookStoreTest
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly PublisherRepository _publisherRepository;
        private readonly TagRepository _tagRepository;
        
        public RepositoryTest(BookStoreFactory factory, ITestOutputHelper testOutputHelper) : base(factory, testOutputHelper)
        {
            _authorRepository = ServiceProvider.GetRequiredService<IAuthorRepository>();
            _publisherRepository = ServiceProvider.GetRequiredService<PublisherRepository>();
            _tagRepository = ServiceProvider.GetRequiredService<TagRepository>();
        }

        [Fact]
        public void Test_RegisteredTypes_FromInterface()
        {
            IRepository<Author> byEntity = ServiceProvider.GetRequiredService<IRepository<Author>>();
            byEntity.Should().BeOfType<AuthorRepository>();
            
            IRepository<Author, Guid> byEntityAndKey = ServiceProvider.GetRequiredService<IRepository<Author, Guid>>();
            byEntityAndKey.Should().BeOfType<AuthorRepository>();
        }

        [Fact]
        public void Test_RegisteredTypes()
        {
            IRepository<Book> byEntity = ServiceProvider.GetRequiredService<IRepository<Book>>();
            byEntity.Should().BeOfType<BookRepository>();
            
            IRepository<Book, Guid> byEntityAndKey = ServiceProvider.GetRequiredService<IRepository<Book, Guid>>();
            byEntityAndKey.Should().BeOfType<BookRepository>();
            
            BookRepository byConcrete = ServiceProvider.GetRequiredService<BookRepository>();
            byConcrete.Should().BeOfType<BookRepository>();
        }

        [Fact]
        public async Task Test_RepositoryBasics()
        {
            _authorRepository.ClrType.Should().Be(typeof(Author));
            _authorRepository.HasChanges.Should().BeFalse();
            (await _authorRepository.GetAllAsync()).Should().HaveCount(1);
            Author? byPk = await _authorRepository.Get(Guid.Parse("6e7c8428-6b49-4c94-b062-af832efd7236"));
            byPk.Should().NotBeNull();
        }

        [Fact]
        public async Task Test_CRUD()
        {
            Author author = new()
            {
                Id = Guid.NewGuid(),
                Email = "crud@author.com",
                Name = "CRUD Author"
            };
            
            _authorRepository.Insert(author);
            await _authorRepository.SaveChangesAsync();
            Author? wasInserted = await _authorRepository.Get(author.Id);
            wasInserted.Should().NotBeNull();

            author.Name = "CRUD Updated";
            _authorRepository.Update(author);
            await _authorRepository.SaveChangesAsync();
            Author? wasChanged = await _authorRepository.Get(author.Id);
            wasChanged.Should().NotBeNull();
            wasChanged.Name.Should().Be("CRUD Updated");
            
            _authorRepository.Remove(author);
            await _authorRepository.SaveChangesAsync();
            Author? wasRemoved = await _authorRepository.Get(author.Id);
            wasRemoved.Should().BeNull();
        }

        [Fact]
        public async Task Test_MultipleChanges()
        {
            Author author = new()
            {
                Id = Guid.NewGuid(),
                Email = "multiple@author.com",
                Name = "Multiple Author"
            };
            Publisher publisher = new()
            {
                Id = Guid.NewGuid(),
                Name = "Multiple publisher"
            };
            
            _authorRepository.Insert(author);
            _publisherRepository.Insert(publisher);
            await _authorRepository.SaveChangesAsync();

            (await _authorRepository.GetAllAsync()).Should().HaveCount(2);
            (await _publisherRepository.GetAllAsync()).Should().HaveCount(1);

            await _publisherRepository.SaveChangesAsync();
            (await _publisherRepository.GetAllAsync()).Should().HaveCount(2);
        }

        [Fact]
        public async Task Test_Query()
        {
            Author author = await _authorRepository.Get(new GetBookwormQuery()).SingleAsync();
            author.Name.Should().Be("Bookworm #1");
        }

        [Fact]
        public async Task Test_CollectionQuery()
        {
            IEnumerable<Tag> tags = await _tagRepository.Find(new AllTagsQuery()).FindAsync();
            tags.First().Id.Should().Be(1);
        }

        [Fact]
        public async Task Test_Pagination()
        {
            // Create ten tags - two are already prepared in the database.
            _tagRepository.InsertRange(new List<Tag>
            {
                new(){Name = "3"}, new(){Name = "4"}, new(){Name = "5"}, new(){Name = "6"}, new(){Name = "7"}, new(){Name = "8"}, new(){Name = "9"}, new(){Name = "10"}
            });
            await _tagRepository.SaveChangesAsync();

            PaginationQuery query = new() { Limit = 5, Offset = 0 };
            PagedCollection<Tag> collection = await _tagRepository.Find(new AllTagsQuery()).FindPagedAsync(query);
            collection.Total.Should().Be(10);
            collection.Limit.Should().Be(collection.Limit);
            collection.Offset.Should().Be(collection.Offset);
            collection.Data.Should().HaveCount(collection.Limit);

            query.Offset = 5;
            collection = await _tagRepository.Find(new AllTagsQuery()).FindPagedAsync(query);
            collection.Data.First().Name.Should().Be("6");
        }
    }
}