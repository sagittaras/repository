using System;
using Microsoft.Extensions.DependencyInjection;

namespace Sagittaras.Repository.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class ServiceExtension
    {
        /// <summary>
        /// Enables usage of repository pattern with the data model.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="options"></param>
        public static void UseRepositoryPattern(this IServiceCollection services, Action<RepositoryPatternBuilderOptions>? options)
        {
            options?.Invoke(new RepositoryPatternBuilderOptions(services));
        }
    }
}