using Sagittaras.Model.TestFramework;
using Xunit.Abstractions;

namespace Sagittaras.Repository.Test.BookStore.Environment.SetUp
{
    /// <summary>
    /// Main class used for tessting in BookStore.
    /// </summary>
    public abstract class BookStoreTest : UnitTest<BookStoreFactory, BookStoreContext>
    {
        protected BookStoreTest(BookStoreFactory factory, ITestOutputHelper testOutputHelper) : base(factory, testOutputHelper)
        {
        }
    }
}