// <copyright file="DataBaseContext.cs" company="Universidad EAFIT">
// Copyright (c) Universidad EAFIT. All rights reserved.
// </copyright>

namespace SmartParkingAppEAFIT.Infrastructure.Data
{
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Clase para representar el contexto de la base de datos utilizando Entity Framework Core.
    /// </summary>
    /// <param name="options">Opciones de configuración para el contexto de la base de datos.</param>
    public class DataBaseContext(DbContextOptions<DataBaseContext> options) : DbContext(options)
    {
        /// <summary>
        /// Este metodo permite configurar el modelo de datos utilizando el ModelBuilder.
        /// Se pueden aplicar configuraciones específicas para cada entidad, como relaciones, restricciones, índices, etc.
        /// En este caso, se están aplicando todas las configuraciones definidas en el ensamblado de la clase DataBaseContext utilizando
        /// el método ApplyConfigurationsFromAssembly.
        /// </summary>
        /// <param name="modelBuilder">El objeto ModelBuilder que se utiliza para configurar el modelo de datos.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataBaseContext).Assembly);
        }
    }
}
