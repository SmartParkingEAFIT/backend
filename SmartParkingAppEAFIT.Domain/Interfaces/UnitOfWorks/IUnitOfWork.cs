// <copyright file="IUnitOfWork.cs" company="Universidad EAFIT">
// Copyright (c) Universidad EAFIT. All rights reserved.
// </copyright>

namespace SmartParkingAppEAFIT.Domain.Interfaces.UnitOfWorks
{
    using System;
    using SmartParkingAppEAFIT.Domain.Interfaces.Examples;

    /// <summary>
    /// Interface para el patrón Unit of Work, que proporciona un método para guardar los cambios realizados en el contexto de datos. Este patrón es útil para coordinar la escritura de cambios a través de múltiples repositorios y garantizar la atomicidad de las operaciones.
    /// La interfaz también hereda de IDisposable para permitir la liberación adecuada de recursos cuando se complete el trabajo.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Gets: Interfaz para el repositorio de ejemplo. Esta propiedad proporciona acceso a las operaciones de datos
        /// relacionadas con la entidad de ejemplo. Al exponer esta propiedad a través de la unidad de trabajo,
        /// se permite a los servicios de la capa de aplicación acceder a los métodos del repositorio sin necesidad
        /// de conocer los detalles de implementación específicos del repositorio.
        /// </summary>
        IExampleRepository ExampleRepository { get; }

        /// <summary>
        /// Metodo para guardar los cambios realizados en el contexto de datos. Este método se encarga
        /// de coordinar la escritura de cambios a través de múltiples repositorios y garantizar la atomicidad de las operaciones.
        /// Al llamar a este método, se persisten todos los cambios realizados en el contexto de datos en una sola transacción.
        /// </summary>
        void SaveChanges();

        /// <summary>
        /// Metodo para guardar los cambios realizados en el contexto de datos de forma asincrónica. Este método se encarga
        /// de coordinar la escritura de cambios a través de múltiples repositorios y garantizar la atomicidad de las operaciones.
        /// Al llamar a este método, se persisten todos los cambios realizados en el contexto de datos en una sola transacción.
        /// </summary>
        /// <returns>El número de registros afectados.</returns>
        Task<int> SaveChangesAsync();

    }
}
