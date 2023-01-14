using Microsoft.Extensions.DependencyInjection;
using Sagittaras.Repository.Extensions;
using Sagittaras.Repository.Queries;
using Sagittaras.Repository.Queries.Projection;

namespace Sagittaras.Repository
{
    /// <summary>
    /// Options for registering a repository pattern.
    /// </summary>
    public class RepositoryPatternBuilderOptions
    {
        internal RepositoryPatternBuilderOptions(IServiceCollection services)
        {
            Services = services;
            Services.AddScoped<IQueryResultFactory, QueryResultFactory>();
            Services.AddSingleton<IProjectionAdapter, NotSupportedProjectionAdapter>();
        }

        /// <summary>
        /// Collection of registered services.
        /// </summary>
        private IServiceCollection Services { get; }

        /// <summary>
        /// Register a new repository to services as direct type.
        /// </summary>
        /// <typeparam name="TImplementation">Implementation type of repository.</typeparam>
        public void AddRepository<TImplementation>() where TImplementation : class, IRepository
        {
            Services.AddScoped<TImplementation>();
            Services.AddScoped<IRepository, TImplementation>(b => b.GetRequiredService<TImplementation>());
        }

        /// <summary>
        /// Registers a new repository to services.
        /// </summary>
        /// <typeparam name="TInterface">Interface of repository</typeparam>
        /// <typeparam name="TImplementation">The implementation type of repository.</typeparam>
        public void AddRepository<TInterface, TImplementation>()
            where TInterface : class, IRepository
            where TImplementation : class, TInterface
        {
            Services.AddScoped<TInterface, TImplementation>();
            Services.AddScoped<IRepository, TImplementation>(b => (TImplementation) b.GetRequiredService<TInterface>());
        }

        /// <summary>
        /// Use a custom implementation of the projection adapter.
        /// </summary>
        /// <typeparam name="TProjectionAdapter"></typeparam>
        public void UseProjectionAdapter<TProjectionAdapter>() where TProjectionAdapter : class, IProjectionAdapter
        {
            Services.ReplaceService<IProjectionAdapter, TProjectionAdapter>();
        }
    }
}