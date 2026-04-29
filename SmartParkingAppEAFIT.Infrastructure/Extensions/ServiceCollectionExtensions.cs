// <copyright file="ServiceCollectionExtensions.cs" company="Universidad EAFIT">
// Copyright (c) Universidad EAFIT. All rights reserved.
// </copyright>

namespace SmartParkingAppEAFIT.Infrastructure.Extensions
{
    using SmartParkingAppEAFIT.Domain.Interfaces.UnitOfWorks;
    using SmartParkingAppEAFIT.Domain.Interfaces.Utils;
    using SmartParkingAppEAFIT.Infrastructure.Data;
    using SmartParkingAppEAFIT.Infrastructure.Http;
    using SmartParkingAppEAFIT.Infrastructure.Repositories.UnitOfWorks;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// Esta clase de extensión proporciona métodos para configurar los servicios de infraestructura en la aplicación,
    /// como el contexto de la base de datos y las dependencias necesarias para los repositorios y servicios.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Agrega el contexto de la base de datos y las dependencias necesarias para los repositorios y servicios a la colección de servicios.
        /// </summary>
        /// <param name="services">La colección de servicios a la que se agregarán las dependencias.</param>
        /// <param name="configuration">La configuración de la aplicación.</param>
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("SQLServerConnection");

            services.AddDbContext<DataBaseContext>(options =>
                options.UseNpgsql(
                    configuration.GetConnectionString("PostgreSQLConnection"),
                    b => b.MigrationsAssembly(typeof(DataBaseContext).Assembly.FullName))
                    );

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddSingleton<IGenericHttpClient, GenericHttpClient>();
        }
    }
}
