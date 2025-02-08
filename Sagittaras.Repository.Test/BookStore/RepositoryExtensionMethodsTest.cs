using System;
using System.Collections.Generic;
using FluentAssertions;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.DependencyInjection;
using Sagittaras.Repository.Extensions;
using Sagittaras.Repository.Test.BookStore.Environment;
using Sagittaras.Repository.Test.BookStore.Environment.Repository;
using Sagittaras.Repository.Test.BookStore.Environment.SetUp;
using Xunit;
using Xunit.Abstractions;

namespace Sagittaras.Repository.Test.BookStore
{
    public class RepositoryExtensionMethodsTest(BookStoreFactory factory, ITestOutputHelper testOutputHelper) : BookStoreTest(factory, testOutputHelper)
    {
        [Fact]
        public void Test_GetPrimaryKey()
        {
            IAuthorRepository authorRepository = ServiceProvider.GetRequiredService<IAuthorRepository>();
            IProperty property = authorRepository.GetPrimaryKeyProperty();
            property.Name.Should().Be(nameof(Author.Id));
        }

        [Fact]
        public void Test_GetPrimaryKeys()
        {
            BookTagRepository bookTagRepository = ServiceProvider.GetRequiredService<BookTagRepository>();
            bookTagRepository.Invoking(i => i.GetPrimaryKeyProperty()).Should().Throw<InvalidOperationException>();
            
            IReadOnlyList<IProperty> properties = bookTagRepository.GetPrimaryKeyProperties();
            properties.Should().HaveCount(2);
            properties.Should().Contain(p => p.Name == nameof(BookTag.BookId));
            properties.Should().Contain(p => p.Name == nameof(BookTag.TagId));
        }
    }
}