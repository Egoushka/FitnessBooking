using System;
using System.Linq;
using System.Reflection;
using Autofac;
using Autofac.Builder;
using FitnessBooking.Api.Helpers;
using FitnessBooking.Business.LongRunning;
using FitnessBooking.Core.Interfaces.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FitnessBooking.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection UseAllOfType<T>(this IServiceCollection serviceCollection, ServiceLifetime lifetime = ServiceLifetime.Scoped)
        {
            return serviceCollection.UseAllOfType<T>(AssemblyHelper.GetSolutionAssemblies());
        }

        public static IServiceCollection UseAllOfType<T>(this IServiceCollection serviceCollection, Assembly[] assemblies, ServiceLifetime lifetime = ServiceLifetime.Scoped)
        {
            var typesFromAssemblies = assemblies.SelectMany(a => a.DefinedTypes.Where(x => x.IsClass && x.GetInterfaces().Contains(typeof(T))));

            foreach (var type in typesFromAssemblies)
            {
                var it = type.GetInterfaces();
                var ind = Array.IndexOf(it, typeof(T)) - 1;

                serviceCollection.Add(new ServiceDescriptor(type.GetInterfaces()[ind], type, lifetime));
            }

            return serviceCollection;
        }

        public static ContainerBuilder UseAllOfType<T>(this ContainerBuilder serviceCollection, ServiceLifetime lifetime = ServiceLifetime.Scoped)
        {
            return serviceCollection.UseAllOfType<T>(AssemblyHelper.GetSolutionAssemblies());
        }

        public static IRegistrationBuilder<object,
            ConcreteReflectionActivatorData,
            SingleRegistrationStyle>
            UseLifetime(this IRegistrationBuilder<object,
                ConcreteReflectionActivatorData,
                SingleRegistrationStyle> regBuilder,
            ServiceLifetime lifetime)
        {
            switch (lifetime)
            {
                case ServiceLifetime.Scoped:
                    return regBuilder.InstancePerLifetimeScope();

                case ServiceLifetime.Singleton:
                    return regBuilder.SingleInstance();

                case ServiceLifetime.Transient:
                    return regBuilder.InstancePerDependency();

                default:
                    return regBuilder.InstancePerDependency();
            }
        }

        public static ContainerBuilder UseAllOfType<T>(this ContainerBuilder serviceCollection, Assembly[] assemblies, ServiceLifetime lifetime = ServiceLifetime.Scoped)
        {
            var typesFromAssemblies = assemblies.SelectMany(a => a.DefinedTypes.Where(x => x.IsClass && x.GetInterfaces().Contains(typeof(T))));

            foreach (var type in typesFromAssemblies)
            {
                var it = type.GetInterfaces();
                var ind = Array.IndexOf(it, typeof(T)) - 1;

                serviceCollection.RegisterType(type)
                   .As(type.GetInterfaces()[ind])
                   .UseLifetime(lifetime);
            }

            return serviceCollection;
        }

        public static ContainerBuilder RegisterAllServices(this ContainerBuilder containerBuilder)
        {
            containerBuilder.UseAllOfType<ISingletonService>(ServiceLifetime.Singleton);
            containerBuilder.UseAllOfType<IScopedService>();
            containerBuilder.UseAllOfType<ITransientService>(ServiceLifetime.Transient);

            return containerBuilder;
        }

        public static IServiceCollection AddLongRunningTasks(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddHostedService<QueuedHostedService>();
            serviceCollection.AddSingleton<IBackgroundTaskQueue, BackgroundTaskQueue>();
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            return serviceCollection;
        }

        public static IServiceCollection DisableCachingForAllHttpCalls(this IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddMvc(options =>
                {
                    // Turns off Caching for the entire API
                    options.Filters.Add(new ResponseCacheAttribute { NoStore = true, Location = ResponseCacheLocation.None });
                });

            return serviceCollection;
        }

        /// <summary>
        /// services.ConfigurePOCO(Configuration.GetSection("MySettings"), () => new MySettings("foo"));
        /// </summary>
        public static TConfig ConfigurePoco<TConfig>(this IServiceCollection services, IConfiguration configuration, Func<TConfig> pocoProvider) where TConfig : class
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            if (pocoProvider == null)
            {
                throw new ArgumentNullException(nameof(pocoProvider));
            }

            var config = pocoProvider();
            configuration.Bind(config);
            services.AddSingleton(config);

            return config;
        }

        public static TConfig ConfigurePoco<TConfig>(this IServiceCollection services, IConfiguration configuration, TConfig config) where TConfig : class
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            if (config == null)
            {
                throw new ArgumentNullException(nameof(config));
            }

            configuration.Bind(config);
            services.AddSingleton(config);
            return config;
        }

        public static TConfig ConfigurePoco<TConfig>(this IServiceCollection services, IConfiguration configuration) where TConfig : class, new()
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            var config = new TConfig();
            configuration.Bind(config);
            services.AddSingleton(config);

            return config;
        }
    }
}