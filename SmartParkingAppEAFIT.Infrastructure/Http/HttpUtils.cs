// <copyright file="HttpUtils.cs" company="Universidad EAFIT">
// Copyright (c) Universidad EAFIT. All rights reserved.
// </copyright>

namespace SmartParkingAppEAFIT.Infrastructure.Http
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// clase de utilidad para realizar solicitudes HTTP, como la ejecución de acciones con un tiempo de espera
    /// y la construcción de encabezados de autenticación.
    /// </summary>
    public static class HttpUtils
    {
        /// <summary>
        /// metodo que ejecuta una acción asincrónica con un tiempo de espera de 30 segundos utilizando un CancellationTokenSource.
        /// </summary>
        /// <typeparam name="T">El tipo de resultado esperado de la acción asincrónica.</typeparam>
        /// <param name="action">La acción asincrónica a ejecutar.</param>
        /// <returns>El resultado de la acción asincrónica, o null si se cancela.</returns>
        public static async Task<T?> ExecuteWithCtsAsync<T>(Func<CancellationToken, Task<T?>> action)
        {
            using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(30));

            return await action(cts.Token).ConfigureAwait(false);
        }

        /// <summary>
        /// Crea un diccionario de encabezados de autenticación utilizando una clave de API proporcionada, con la clave "Authorization
        /// </summary>
        /// <param name="apiKey">La clave de API utilizada para la autenticación.</param>
        /// <returns>Un diccionario de encabezados de autenticación con la clave "Authorization".</returns>
        public static IDictionary<string, string> BuildAuthHeaders(string? apiKey)
        => new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            { "Authorization", $"Bearer {apiKey}" },
        };
    };
}
