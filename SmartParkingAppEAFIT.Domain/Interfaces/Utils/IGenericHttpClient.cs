// <copyright file="IGenericHttpClient.cs" company="Universidad EAFIT">
// Copyright (c) Universidad EAFIT. All rights reserved.
// </copyright>

namespace SmartParkingAppEAFIT.Domain.Interfaces.Utils
{
    using System.Collections.Generic;

    /// <summary>
    /// Interface para un cliente HTTP genérico que proporciona métodos para enviar solicitudes HTTP (POST, GET, PUT, DELETE)
    /// con cuerpos de solicitud fuertemente tipados y deserializar las respuestas a tipos específicos. Este cliente puede ser utilizado para
    /// interactuar con APIs RESTful de manera flexible y reutilizable en toda la aplicación.
    /// </summary>
    public interface IGenericHttpClient
    {
        /// <summary>
        /// Metodo para enviar una solicitud POST con un cuerpo de solicitud fuertemente tipado y deserializar la respuesta a TResponse.
        /// </summary>
        /// <typeparam name="TRequest">Objeto que representa el cuerpo de la solicitud.</typeparam>
        /// <typeparam name="TResponse">Objeto que representa la respuesta de la solicitud.</typeparam>
        /// <param name="url">La URL a la que se enviará la solicitud.</param>
        /// <param name="body">El cuerpo de la solicitud.</param>
        /// <param name="headers">Encabezados opcionales para la solicitud.</param>
        /// <param name="cancellationToken">Token de cancelación opcional.</param>
        /// <returns>La respuesta deserializada a TResponse.</returns>
        Task<TResponse?> PostAsync<TRequest, TResponse>(
            string url,
            TRequest body,
            IDictionary<string, string>? headers = null,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Metodo para enviar una solicitud GET y deserializar la respuesta a TResponse. Permite incluir encabezados opcionales y un token de cancelación.
        /// </summary>
        /// <typeparam name="TResponse">Objeto que representa la respuesta de la solicitud.</typeparam>
        /// <param name="url">La URL a la que se enviará la solicitud.</param>
        /// <param name="headers">Encabezados opcionales para la solicitud.</param>
        /// <param name="cancellationToken">Token de cancelación opcional.</param>
        /// <returns>La respuesta deserializada a TResponse.</returns>
        Task<TResponse?> GetAsync<TResponse>(
            string url,
            IDictionary<string, string>? headers = null,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Metodo para enviar una solicitud PUT con un cuerpo de solicitud fuertemente tipado y deserializar la respuesta a TResponse.
        /// </summary>
        /// <typeparam name="TRequest">Objeto que representa el cuerpo de la solicitud.</typeparam>
        /// <typeparam name="TResponse">Objeto que representa la respuesta de la solicitud.</typeparam>
        /// <param name="url">La URL a la que se enviará la solicitud.</param>
        /// <param name="body">El cuerpo de la solicitud.</param>
        /// <param name="headers">Encabezados opcionales para la solicitud.</param>
        /// <param name="cancellationToken">Token de cancelación opcional.</param>
        /// <returns>La respuesta deserializada a TResponse.</returns>
        Task<TResponse?> PutAsync<TRequest, TResponse>(
            string url,
            TRequest body,
            IDictionary<string, string>? headers = null,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Metodo para enviar una solicitud DELETE y deserializar la respuesta a TResponse.
        /// </summary>
        /// <typeparam name="TResponse">Objeto que representa la respuesta de la solicitud.</typeparam>
        /// <param name="url">La URL a la que se enviará la solicitud.</param>
        /// <param name="headers">Encabezados opcionales para la solicitud.</param>
        /// <param name="cancellationToken">Token de cancelación opcional.</param>
        /// <returns>La respuesta deserializada a TResponse.</returns>
        Task<TResponse?> DeleteAsync<TResponse>(
            string url,
            IDictionary<string, string>? headers = null,
            CancellationToken cancellationToken = default);
    }
}
