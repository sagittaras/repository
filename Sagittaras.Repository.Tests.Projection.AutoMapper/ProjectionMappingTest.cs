using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Sagittaras.Repository.Tests.Projection.AutoMapper.Environment;
using Sagittaras.Repository.Tests.Projection.AutoMapper.Environment.Repository;
using Sagittaras.Repository.Tests.Projection.AutoMapper.Environment.SetUp;
using Xunit.Abstractions;

namespace Sagittaras.Repository.Tests.Projection.AutoMapper;

public class ProjectionMappingTest : MappingTest
{
    private readonly UserRepository _userRepository;

    public ProjectionMappingTest(MappingFactory factory, ITestOutputHelper testOutputHelper) : base(factory, testOutputHelper)
    {
        _userRepository = ServiceProvider.GetRequiredService<UserRepository>();
    }

    [Fact]
    public async Task Test_ProjectToDto()
    {
        UserDto dto = await _userRepository.Get(new GetUserById(1)).SingleProjectedAsync<UserDto>();
        dto.Should().BeOfType<UserDto>();
        dto.Id.Should().Be(1);
    }
}