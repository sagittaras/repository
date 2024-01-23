using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Sagittaras.Model.TestFramework;
using Sagittaras.Repository.Extensions;
using Sagittaras.Repository.Test.Mapping.Environment.Projection;
using Sagittaras.Repository.Test.Mapping.Environment.Repository;

namespace Sagittaras.Repository.Test.Mapping.Environment.SetUp
{
    public class MappingFactory : TestFactory
    {
        /// <summary>
        /// Overrides the name of connection string to match the requirements in our pipeline.
        /// </summary>
        protected override string ConnectionString => "Default";

        protected override void OnConfiguring(ServiceCollection services)
        {
            services.AddDbContext<MappingContext>(contextOptions =>
            {
                contextOptions.UseNpgsql(GetConnectionString(Engine.DbEngine));
                contextOptions.UseLazyLoadingProxies();
            });
            services.AddScoped<DbContext>(b => b.GetRequiredService<MappingContext>());
            services.UseRepositoryPattern(options =>
            {
                options.AddRepository<UserRepository>();
                options.UseProjectionAdapter<AutoMapperAdapter>();
            });
            services.AddAutoMapper(typeof(MappingFactory).Assembly);
        }
    }
}