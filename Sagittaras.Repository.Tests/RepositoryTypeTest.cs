using System;
using System.Linq;
using FluentAssertions;
using Sagittaras.Repository.Tests.BookStore.Environment.Repository;
using Xunit;

namespace Sagittaras.Repository.Tests;

public class RepositoryTypeTest
{
    [Fact]
    public void Test_GetInterfaces()
    {
        Type type = typeof(AuthorRepository);
        Type[] interfaces = type.GetInterfaces().Where(x => x.IsAssignableTo(typeof(IRepository))).ToArray();
        interfaces.Should().HaveCount(4);
    }
}