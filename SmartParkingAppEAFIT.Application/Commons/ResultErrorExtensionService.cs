// <copyright file="ResultErrorExtensionService.cs" company="Universidad EAFIT">
// Copyright (c) Universidad EAFIT. All rights reserved.
// </copyright>

namespace SmartParkingAppEAFIT.Application.Commons
{
    using SmartParkingAppEAFIT.Domain.Commons.Results;

    /// <summary>
    /// Clase de extensión para manejar errores en los resultados de las operaciones.
    /// </summary>
    public static class ResultErrorExtensionService
    {
        /// <summary>
        /// Metodo de extensión para crear un resultado de error con un código de error específico y un mensaje personalizado.
        /// </summary>
        /// <typeparam name="T">El tipo del valor devuelto por la operación.</typeparam>
        /// <param name="errorCode">El código de error que ocurrió.</param>
        /// <param name="message">El mensaje descriptivo del error.</param>
        /// <returns>Un nuevo <see cref="Result{T}"/> fallido con el error especificado.</returns>
        public static Result<T> ErrorEventArgs<T>(ResultErrorType errorCode, string message)
        {
            var error = new ResultError(errorCode, message);

            return Result<T>.Fail(error);
        }
    }
}
