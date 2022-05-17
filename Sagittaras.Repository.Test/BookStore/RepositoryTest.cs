using System;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Sagittaras.Repository.Test.BookStore.Environment;
using Sagittaras.Repository.Test.BookStore.Environment.Repository;
using Sagittaras.Repository.Test.BookStore.Environment.SetUp;
using Xunit;
using Xunit.Abstractions;

namespace Sagittaras.Repository.Test.BookStore
{
    public class RepositoryTest : BookStoreTest
    {
        private readonly AuthorRepository _authorRepository;
        private readonly PublisherRepository _publisherRepository;
        
        public RepositoryTest(BookStoreFactory factory, ITestOutputHelper testOutputHelper) : base(factory, testOutputHelper)
        {
            _authorRepository = ServiceProvider.GetRequiredService<AuthorRepository>();
            _publisherRepository = ServiceProvider.GetRequiredService<PublisherRepository>();
        }

        [Fact]
        public async Task Test_RepositoryBasics()
        {
            _authorRepository.EntityType.Should().Be(typeof(Author));
            _authorRepository.HasChanges.Should().BeFalse();
            (await _authorRepository.GetAll()).Should().HaveCount(1);
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
            wasChanged!.Name.Should().Be("CRUD Updated");
            
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

            (await _authorRepository.GetAll()).Should().HaveCount(2);
            (await _publisherRepository.GetAll()).Should().HaveCount(1);

            await _publisherRepository.SaveChangesAsync();
            (await _publisherRepository.GetAll()).Should().HaveCount(2);
        }
    }
}