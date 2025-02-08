using Sagittaras.Model.TestFramework;
using Xunit.Abstractions;

namespace Sagittaras.Repository.Tests.BookStore.Environment.SetUp;

/// <summary>
///     Main class used for testing in BookStore.
/// </summary>
public abstract class BookStoreTest(BookStoreFactory factory, ITestOutputHelper testOutputHelper) : UnitTest<BookStoreFactory, BookStoreContext>(factory, testOutputHelper);