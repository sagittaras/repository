using System;
using System.Linq;
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
        
        /// <summary>
        /// Replaces <see cref="ServiceDescriptor"/> of selected service type with new implementation.
        /// </summary>
        /// <param name="services">Extended instance of service collection.</param>
        /// <typeparam name="TServiceType">Type of service to be replaced.</typeparam>
        /// <typeparam name="TReplacementType">Type of replacing service.</typeparam>
        internal static void ReplaceService<TServiceType, TReplacementType>(this IServiceCollection services)
            where TServiceType : class
            where TReplacementType : class, TServiceType
        {
            Type serviceType = typeof(TServiceType);
            Type replacementType = typeof(TReplacementType);
            
            ServiceDescriptor? descriptor = services.SingleOrDefault(d => d.ServiceType == serviceType);
            if (descriptor is null)
            {
                services.AddScoped(serviceType, replacementType);
            }
            else
            {
                ServiceDescriptor replacement = new(descriptor.ServiceType, replacementType, descriptor.Lifetime);
                services.Remove(descriptor);
                services.Add(replacement);
            }
        }
    }
}