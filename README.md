# Sagittaras.Repository by [Sagittaras Games](https://github.com/sagittaras)

Implementation of Generic Repository Pattern.

## Usage

Repository pattern provides an extra layer for accessing entities data in database without direct access
to database context class.

Your entity operations and queries are grouped together in one single class.

### Define your repository

To define your repository just extends `Repository<TEntity, TKey>` class, providing the type of entity
and the type of its primary key.

```csharp
public class AuthorRepository : Repository<Author, Guid>
{
    public AuthorRepository(DbContext dbContext) : base(dbContext)
    {
    }
}
```

### Composite key

If your entity is using composite key (only two primary keys are supported), extends instead `Repository<TEntity, TFirstKey, TSecondKey>`
class.

```csharp
public class BookTagRepository : Repository<BookTag, Guid, int>
{
    public BookTagRepository(DbContext dbContext) : base(dbContext)
    {
    }
}
```

### Using interfaces

When you prefer to describe your repositories by interfaces, you can simply use interfaces equivalents to base classes.

```csharp
public interface IAuthorRepository : IRepository<Author, Guid>
{
    Task<Author> GetByEmail(string email);
}
```

And then our repository...

```csharp
public class AuthorRepository : Repository<Author, Guid>, IAuthorRepository 
{
    public BookTagRepository(DbContext dbContext) : base(dbContext)
    {
    }
    
    public Task<Author> GetByEmail(string email) 
    {
        throw new NotImplementedException();
    }
}
```

### Register your repositories

Repositories can be easily registered to Dependency Container via extension method for the `IServiceCollection`.

```csharp
ServiceCollection services = new();

services.UseRepositoryPattern(options =>
{
    options.AddRepository<IAuthorRepository, AuthorRepository>();
    options.AddRepository<BookRepository>();
    options.AddRepository<PublisherRepository>();
    options.AddRepository<BookTagRepository>();
});
```

Repositories can be registered only by their type or in combination with interface. All registered repositories
are also registered under the `IRepository` type.

**Current lifetime of repositories is Scoped.**

### Accessing data

The repository is providing `Queryable` property, which can be used to read the data from database.

```csharp
public class AuthorRepository : Repository<Author, Guid>, IAuthorRepository 
{
    public BookTagRepository(DbContext dbContext) : base(dbContext)
    {
    }
    
    public async Task<Author> GetByEmail(string email) 
    {
        return await Queryable.SingleAsync(e => e.Email == email);
    }
}
```

### Saving data

Repository is providing methods for `Insert`, `Update`, `Remove` and their Range equivalents.

```csharp
IAuthorRepository repo = ServiceProvider.GetService<IAuthorRepository>();
Author author = new(){
    Email = "john.doe@example.com",
    FirstName = "John",
    LastName = "Doe"
}
repo.Insert(author);
await repo.SaveChangesAsync();
```

CRUD operations made to the repository needs to be saved by `SaveChanges()` or `SaveChangesAsync()` methods on
**Repository**. This methods writes all unapplied changes to database context and saves them to the database.

### Joining another DbSets

Repository also provides a `Join<TAnotherEntity>()` method, which can be used in join statements, to join another
DbSets in the query.