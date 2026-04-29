// <copyright file="UnitOfWork.cs" company="Universidad EAFIT">
// Copyright (c) Universidad EAFIT. All rights reserved.
// </copyright>

namespace SmartParkingAppEAFIT.Infrastructure.Repositories.UnitOfWorks
{
    using System;
    using SmartParkingAppEAFIT.Domain.Interfaces.Examples;
    using SmartParkingAppEAFIT.Domain.Interfaces.UnitOfWorks;
    using SmartParkingAppEAFIT.Infrastructure.Data;
    using SmartParkingAppEAFIT.Infrastructure.Repositories.Example;

    /// <summary>
    /// Clase que implementa el patrón Unit of Work.
    /// </summary>
    /// <param name="dataBaseContext">El contexto de la base de datos utilizado para las operaciones de la unidad de trabajo.</param>
    public class UnitOfWork(DataBaseContext dataBaseContext) : IUnitOfWork
    {
        /// <summary>
        /// Gets or sets the repository used for accessing example entities.
        /// </summary>
        private IExampleRepository? exampleRepository;

        /// <summary>
        /// Gets: El repositorio de ejemplo utilizado para acceder a las operaciones de datos relacionadas con la entidad de ejemplo.
        /// Esta propiedad proporciona acceso a los métodos del repositorio sin necesidad de conocer los detalles de implementación específicos del repositorio. Al acceder a esta propiedad, se crea una instancia del repositorio si aún no existe,
        /// }utilizando el contexto de la base de datos proporcionado a la unidad de trabajo.
        /// </summary>
        public IExampleRepository ExampleRepository => this.exampleRepository ??= new ExampleRepository(dataBaseContext);

        /// <summary>
        /// Libera los recursos de la unidad de trabajo.
        /// </summary>
        public void Dispose()
        {
            dataBaseContext?.Dispose();

            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Metodo que se encarga de guardar los cambios realizados en la base de datos a través de la unidad de trabajo.
        /// </summary>
        public void SaveChanges()
        {
            dataBaseContext.SaveChanges();
        }

        /// <summary>
        /// Guarda los cambios en la base de datos de forma asíncrona.
        /// </summary>
        /// <returns>Número de registros afectados.</returns>
        public async Task<int> SaveChangesAsync()
        {
            var response = await dataBaseContext.SaveChangesAsync();

            return response;
        }
    }
}
