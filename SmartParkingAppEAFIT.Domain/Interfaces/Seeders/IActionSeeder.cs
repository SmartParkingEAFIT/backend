// <copyright file="IActionSeeder.cs" company="Universidad EAFIT">
// Copyright (c) Universidad EAFIT. All rights reserved.
// </copyright>

namespace SmartParkingAppEAFIT.Domain.Interfaces.Seeders
{
    /// <summary>
    /// Interface para la siembra de acciones en la base de datos.
    /// </summary>
    public interface IActionSeeder
    {
        /// <summary>
        /// Inicializa la siembra de acciones en la base de datos.
        /// </summary>
        /// <returns>Una tarea que representa la operación asincrónica.</returns>
        Task Seed();
    }
}
