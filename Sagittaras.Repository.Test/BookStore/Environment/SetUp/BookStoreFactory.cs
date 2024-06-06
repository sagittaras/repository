using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Sagittaras.Model.TestFramework;
using Sagittaras.Repository.Extensions;
using Sagittaras.Repository.Test.BookStore.Environment.Repository;

namespace Sagittaras.Repository.Test.BookStore.Environment.SetUp
{
    public class BookStoreFactory : TestFactory
    {
        /// <summary>
        /// Overrides the default connection string name to match our pipeline needs.
        /// </summary>
        protected override string ConnectionString => "Default";

        protected override void OnConfiguring(ServiceCollection services)
        {
            services.AddDbContext<BookStoreContext>(contextOptions =>
            {
                contextOptions.UseNpgsql(GetConnectionString(Engine.DbEngine));
                contextOptions.UseLazyLoadingProxies();
                contextOptions.EnableDetailedErrors();
                contextOptions.EnableSensitiveDataLogging();
            });
            services.AddScoped<DbContext>(b => b.GetRequiredService<BookStoreContext>());
            services.UseRepositoryPattern(options =>
            {
                options.AddRepository<IAuthorRepository, AuthorRepository>();
                options.AddRepository<BookRepository>();
                options.AddRepository<PublisherRepository>();
                options.AddRepository<BookTagRepository>();
                options.AddRepository<TagRepository>();
            });
        }
    }
}