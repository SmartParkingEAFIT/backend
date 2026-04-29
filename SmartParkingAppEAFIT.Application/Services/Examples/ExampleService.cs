// <copyright file="ExampleService.cs" company="Universidad EAFIT">
// Copyright (c) Universidad EAFIT. All rights reserved.
// </copyright>

namespace SmartParkingAppEAFIT.Application.Services.Examples
{
    using System;
    using SmartParkingAppEAFIT.Application.Commons.Messages;
    using SmartParkingAppEAFIT.Domain.Commons.Results;
    using SmartParkingAppEAFIT.Domain.Interfaces.Examples;
    using SmartParkingAppEAFIT.Domain.Interfaces.UnitOfWorks;

    /// <summary>
    /// Clase de ejemplo que implementa la interfaz IExampleService.
    /// Esta clase es un ejemplo de cómo se pueden implementar los servicios en la capa de aplicación.
    /// </summary>
    public class ExampleService(IUnitOfWork unitOfWork) : IExampleService
    {
        /// <summary>
        /// Metodo de ejemplo que retorna un resultado exitoso con un mensaje y un valor.
        /// </summary>
        /// <returns>Retorna un <see cref="Result{T}"/> que contiene un valor de tipo string.</returns>
        public async Task<Result<string>> GetExampleResult()
        {
            try
            {
                // Logica de negocio
                // Acceder a la capa de infraestructura.
                // Ejemplo de uso del unit of work para acceder a un repositorio
                var exampleData = await unitOfWork.ExampleRepository.GetExampleData();

                return Result<string>.Success(exampleData, SuccessMessages.OperationSuccess);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Metodo de ejemplo que retorna un valor de tipo string.
        /// </summary>
        /// <returns>Retorna un valor de tipo string.</returns>
        public async Task<string> GetExampleValue()
        {
            try
            {
                // Logica de negocio
                // Acceder a la capa de infraestructura.
                // Ejemplo de uso del unit of work para acceder a un repositorio
                var exampleData = await unitOfWork.ExampleRepository.GetExampleData();

                return exampleData;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
