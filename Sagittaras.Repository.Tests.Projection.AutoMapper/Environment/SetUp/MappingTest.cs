using Sagittaras.Model.TestFramework;
using Xunit.Abstractions;

namespace Sagittaras.Repository.Tests.Projection.AutoMapper.Environment.SetUp
{
    public class MappingTest(MappingFactory factory, ITestOutputHelper testOutputHelper) : UnitTest<MappingFactory, MappingContext>(factory, testOutputHelper);
}