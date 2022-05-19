using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Sagittaras.Model.TestFramework;
using Sagittaras.Repository.Extensions;
using Sagittaras.Repository.Test.BookStore.Environment.Repository;

namespace Sagittaras.Repository.Test.BookStore.Environment.SetUp
{
    public class BookStoreFactory : TestFactory
    {
        protected override void OnConfiguring(ServiceCollection services)
        {
            services.AddDbContext<BookStoreContext>(contextOptions =>
            {
                contextOptions.UseNpgsql(GetConnectionString(Engine.DbEngine));
                contextOptions.UseLazyLoadingProxies();
            });
            services.AddScoped<DbContext>(b => b.GetRequiredService<BookStoreContext>());
            services.UseRepositoryPattern(options =>
            {
                options.AddRepository<AuthorRepository>();
                options.AddRepository<BookRepository>();
                options.AddRepository<PublisherRepository>();
                options.AddRepository<BookTagRepository>();
            });
        }
    }
}