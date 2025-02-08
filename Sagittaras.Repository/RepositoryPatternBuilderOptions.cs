using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Sagittaras.Repository.Extensions;
using Sagittaras.Repository.Queries;
using Sagittaras.Repository.Queries.Projection;

namespace Sagittaras.Repository;

/// <summary>
///     Options for registering a repository pattern.
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
    ///     Collection of registered services.
    /// </summary>
    private IServiceCollection Services { get; }

    /// <summary>
    ///     Register a new repository to services as direct type.
    /// </summary>
    /// <typeparam name="TImplementation">Implementation type of repository.</typeparam>
    public void AddRepository<TImplementation>() where TImplementation : class, IRepository
    {
        Services.AddScoped<TImplementation>();
        RegisterAlternateWays(typeof(TImplementation));
    }

    /// <summary>
    ///     Registers a new repository to services.
    /// </summary>
    /// <typeparam name="TInterface">Interface of repository</typeparam>
    /// <typeparam name="TImplementation">The implementation type of repository.</typeparam>
    public void AddRepository<TInterface, TImplementation>()
        where TInterface : class, IRepository
        where TImplementation : class, TInterface
    {
        Services.AddScoped<TInterface, TImplementation>();
        RegisterAlternateWays(typeof(TImplementation), typeof(TInterface));
    }

    /// <summary>
    ///     Use a custom implementation of the projection adapter.
    /// </summary>
    /// <typeparam name="TProjectionAdapter"></typeparam>
    public void UseProjectionAdapter<TProjectionAdapter>() where TProjectionAdapter : class, IProjectionAdapter
    {
        Services.ReplaceService<IProjectionAdapter, TProjectionAdapter>();
    }

    /// <summary>
    ///     Register all alternate ways how we can have repository accessible.
    /// </summary>
    /// <remarks>
    ///     Repository can by accessible under these ways:
    ///     - IRepository&lt;TEntity&gt;
    ///     - IRepository&lt;TEntity, TKey&gt;
    ///     - Custom repository interface
    /// </remarks>
    /// <param name="implementationType"></param>
    /// <param name="callType"></param>
    private void RegisterAlternateWays(Type implementationType, Type? callType = null)
    {
        foreach (Type repositoryInterface in implementationType.GetInterfaces().Where(x => x.IsAssignableTo(typeof(IRepository))))
        {
            // I.e. If repository is registered as IAuthorRepository, we don't want register this interface again. Never-ending loop.
            if (repositoryInterface == callType) continue;

            Services.AddScoped(repositoryInterface, b => b.GetRequiredService(callType ?? implementationType));
        }
    }
}