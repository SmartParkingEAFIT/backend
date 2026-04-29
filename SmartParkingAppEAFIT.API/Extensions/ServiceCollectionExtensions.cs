// <copyright file="ServiceCollectionExtensions.cs" company="Universidad EAFIT">
// Copyright (c) Universidad EAFIT. All rights reserved.
// </copyright>

namespace SmartParkingAppEAFIT.API.Extensions
{
    using System.Reflection;
    using FluentValidation;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// Extension methods for configuring services in the Convocatorias function app.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Registers FluentValidation validators from the current function assembly.
        /// </summary>
        /// <param name="services">The service collection to add validators to.</param>
        /// <returns>The service collection for chaining.</returns>
        public static IServiceCollection AddFunctionValidators(this IServiceCollection services)
        {
            // Register all validators from the current Convocatorias assembly
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
