// <copyright file="ServiceCollectionExtensions.cs" company="Universidad EAFIT">
// Copyright (c) Universidad EAFIT. All rights reserved.
// </copyright>

namespace SmartParkingAppEAFIT.Application.Extensions
{
    using Microsoft.Extensions.DependencyInjection;
    using SmartParkingAppEAFIT.Application.Services.Examples;
    using SmartParkingAppEAFIT.Domain.Interfaces.Examples;

    /// <summary>
    /// Extension methods for configuring application services in the dependency injection container.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Registers all application layer services (use cases, business logic, etc.) to the service collection.
        /// </summary>
        /// <param name="services">The service collection to add services to.</param>
        /// <returns>The service collection for chaining.</returns>
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Register your application services here
            // Example:
            // services.AddScoped<IConvocatoriaService, ConvocatoriaService>();
            // services.AddScoped<IPostulacionService, PostulacionService>();

            services.AddScoped<IExampleService, ExampleService>();

            return services;
        }
    }
}
