// <copyright file="GenericHttpClient.cs" company="Universidad EAFIT">
// Copyright (c) Universidad EAFIT. All rights reserved.
// </copyright>

namespace SmartParkingAppEAFIT.Infrastructure.Http
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text;
    using System.Text.Json;
    using SmartParkingAppEAFIT.Domain.Interfaces.Utils;

    /// <summary>
    /// Clase para realizar solicitudes HTTP genéricas utilizando HttpClientFactory.
    /// </summary>
    /// <param name="httpClientFactory">La fábrica de HttpClient utilizada para crear instancias de HttpClient.</param>
    public class GenericHttpClient(IHttpClientFactory httpClientFactory) : IGenericHttpClient
    {
        private readonly HttpClient httpClient = httpClientFactory.CreateClient();

        private readonly JsonSerializerOptions jsonOptions = new (JsonSerializerDefaults.Web)
        {
            PropertyNameCaseInsensitive = true,
        };

        /// <summary>
        /// Metodo genérico para realizar una solicitud HTTP POST a una URL especificada, con un cuerpo de solicitud opcional y encabezados personalizados.
        /// </summary>
        /// <typeparam name="TRequest">El tipo del cuerpo de la solicitud.</typeparam>
        /// <typeparam name="TResponse">El tipo de la respuesta esperada.</typeparam>
        /// <param name="url">La URL a la que se enviará la solicitud.</param>
        /// <param name="body">El cuerpo de la solicitud.</param>
        /// <param name="headers">Encabezados personalizados para la solicitud.</param>
        /// <param name="cancellationToken">Token de cancelación para la solicitud.</param>
        /// <returns>La respuesta deserializada del tipo especificado.</returns>
        public async Task<TResponse?> PostAsync<TRequest, TResponse>(string url, TRequest body, IDictionary<string, string>? headers = null, CancellationToken cancellationToken = default)
        {
            using var request = new HttpRequestMessage(HttpMethod.Post, url);

            if (body is not null)
            {
                var json = JsonSerializer.Serialize(body, this.jsonOptions);

                request.Content = new StringContent(json, Encoding.UTF8, "application/json");
            }

            AddDefaultAndCustomHeaders(request, headers);

            return await this.SendRequestAsync<TResponse>(request, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Metodo genérico para realizar una solicitud HTTP GET a una URL especificada, con encabezados personalizados opcionales.
        /// </summary>
        /// <typeparam name="TResponse">El tipo de la respuesta esperada.</typeparam>
        /// <param name="url">La URL a la que se enviará la solicitud.</param>
        /// <param name="headers">Encabezados personalizados para la solicitud.</param>
        /// <param name="cancellationToken">Token de cancelación para la solicitud.</param>
        /// <returns>La respuesta deserializada del tipo especificado.</returns>
        public async Task<TResponse?> GetAsync<TResponse>(string url, IDictionary<string, string>? headers = null, CancellationToken cancellationToken = default)
        {
            using var request = new HttpRequestMessage(HttpMethod.Get, url);

            AddDefaultAndCustomHeaders(request, headers);

            return await this.SendRequestAsync<TResponse>(request, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Metodo genérico para realizar una solicitud HTTP PUT a una URL especificada, con un cuerpo de solicitud opcional y encabezados personalizados.
        /// </summary>
        /// <typeparam name="TRequest">El tipo del cuerpo de la solicitud.</typeparam>
        /// <typeparam name="TResponse">El tipo de la respuesta esperada.</typeparam>
        /// <param name="url">La URL a la que se enviará la solicitud.</param>
        /// <param name="body">El cuerpo de la solicitud.</param>
        /// <param name="headers">Encabezados personalizados para la solicitud.</param>
        /// <param name="cancellationToken">Token de cancelación para la solicitud.</param>
        /// <returns>La respuesta deserializada del tipo especificado.</returns>
        public async Task<TResponse?> PutAsync<TRequest, TResponse>(string url, TRequest body, IDictionary<string, string>? headers = null, CancellationToken cancellationToken = default)
        {
            using var request = new HttpRequestMessage(HttpMethod.Put, url);

            if (body is not null)
            {
                var json = JsonSerializer.Serialize(body, this.jsonOptions);

                request.Content = new StringContent(json, Encoding.UTF8, "application/json");
            }

            AddDefaultAndCustomHeaders(request, headers);

            return await this.SendRequestAsync<TResponse>(request, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Metodo genérico para realizar una solicitud HTTP DELETE a una URL especificada, con encabezados personalizados opcionales.
        /// </summary>
        /// <typeparam name="TResponse">El tipo de la respuesta esperada.</typeparam>
        /// <param name="url">La URL a la que se enviará la solicitud.</param>
        /// <param name="headers">Encabezados personalizados para la solicitud.</param>
        /// <param name="cancellationToken">Token de cancelación para la solicitud.</param>
        /// <returns>La respuesta deserializada del tipo especificado.</returns>
        public async Task<TResponse?> DeleteAsync<TResponse>(string url, IDictionary<string, string>? headers = null, CancellationToken cancellationToken = default)
        {
            using var request = new HttpRequestMessage(HttpMethod.Delete, url);

            AddDefaultAndCustomHeaders(request, headers);

            return await this.SendRequestAsync<TResponse>(request, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Metodo privado para agregar encabezados predeterminados y personalizados a una solicitud HTTP.
        /// </summary>
        /// <param name="request">La solicitud HTTP a la que se agregarán los encabezados.</param>
        /// <param name="headers">Encabezados personalizados para la solicitud.</param>
        private static void AddDefaultAndCustomHeaders(HttpRequestMessage request, IDictionary<string, string>? headers)
        {
            request.Headers.TryAddWithoutValidation("Accept", "application/json");

            if (headers == null)
            {
                return;
            }

            foreach (var kvp in headers)
            {
                if (string.IsNullOrEmpty(kvp.Key))
                {
                    continue;
                }

                request.Headers.Remove(kvp.Key);

                request.Headers.Add(kvp.Key, kvp.Value);
            }
        }

        /// <summary>
        /// Metodo privado para enviar una solicitud HTTP y manejar la respuesta, incluyendo la deserialización del contenido
        /// de la respuesta al tipo especificado y el manejo de errores HTTP.
        /// </summary>
        /// <typeparam name="TResponse">El tipo de la respuesta esperada.</typeparam>
        /// <param name="request">La solicitud HTTP a enviar.</param>
        /// <param name="cancellationToken">Token de cancelación para la solicitud.</param>
        /// <returns>La respuesta deserializada del tipo especificado.</returns>
        /// <exception cref="HttpRequestException">Se lanza cuando la solicitud HTTP falla.</exception>
        private async Task<TResponse?> SendRequestAsync<TResponse>(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            using var response = await this.httpClient.SendAsync(request, cancellationToken).ConfigureAwait(false);

            var responseContent = response.Content is not null
                ? await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false)
                : string.Empty;

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"HTTP {request.Method} {request.RequestUri} failed ({(int)response.StatusCode}): {responseContent}");
            }

            if (string.IsNullOrWhiteSpace(responseContent))
            {
                return default;
            }

            return JsonSerializer.Deserialize<TResponse>(responseContent, this.jsonOptions);
        }
    }
}
