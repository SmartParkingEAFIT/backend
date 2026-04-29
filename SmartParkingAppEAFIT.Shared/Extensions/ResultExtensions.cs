// <copyright file="ResultExtensions.cs" company="Universidad EAFIT">
// Copyright (c) Universidad EAFIT. All rights reserved.
// </copyright>

namespace SmartParkingAppEAFIT.Shared.Extensions
{
    using Microsoft.AspNetCore.Mvc;
    using SmartParkingAppEAFIT.Domain.Commons.Results;

    /// <summary>
    /// Clase de extensión para convertir un objeto Result<T> en un IActionResult adecuado para su uso en controladores de ASP.NET Core y HttpResponseData para Azure Functions.
    /// </summary>
    public static class ResultExtensions
    {

        /// <typeparam name="T">Tipo del resultado.</typeparam>
        /// <param name="result">El resultado de la operación.</param>
        /// <param name="controller">El controlador desde el cual se llama al método.</param>
        /// <returns>Un IActionResult que representa el resultado de la operación.</returns>
        /// <summary>
        /// Metodo de extensión para convertir un objeto Result<T> en un IActionResult adecuado para su uso en controladores de
        /// ASP.NET Core.
        /// </summary>
        public static IActionResult ToActionResult<T>(this Result<T> result, ControllerBase controller)
        {
            if (result is null)
            {
                return controller.StatusCode(500);
            }

            if (result.IsSuccess)
            {
                var value = result.ResultSuccess;

                return value is null ? controller.NoContent() : controller.Ok(value);
            }

            var error = result.ResultError!;

            return error.ErrorCodeType switch
            {
                ResultErrorType.Validation =>
                    controller.BadRequest(error),
                ResultErrorType.BusinessRule =>
                    controller.UnprocessableEntity(error),
                ResultErrorType.NotFound =>
                    controller.NotFound(error),
                ResultErrorType.Conflict =>
                    controller.Conflict(error),
                ResultErrorType.Unauthorized =>
                    controller.Conflict(error),
                ResultErrorType.Forbidden =>
                    controller.Conflict(error),
                _ =>
                    controller.Conflict(error)
            };
        }
    }
}
