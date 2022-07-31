using Sagittaras.Model.TestFramework;
using Xunit.Abstractions;

namespace Sagittaras.Repository.Test.Mapping.Environment.SetUp
{
    public class MappingTest : UnitTest<MappingFactory, MappingContext>
    {
        public MappingTest(MappingFactory factory, ITestOutputHelper testOutputHelper) : base(factory, testOutputHelper)
        {
        }
    }
}