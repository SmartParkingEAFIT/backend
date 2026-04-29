// <copyright file="ResultSuccess.cs" company="Universidad EAFIT">
// Copyright (c) Universidad EAFIT. All rights reserved.
// </copyright>

namespace SmartParkingAppEAFIT.Domain.Commons.Results
{
    /// <summary>
    /// Clase que representa un resultado exitoso de una operación,
    /// proporcionando un valor de tipo <typeparamref name="T"/> y un mensaje descriptivo.
    /// </summary>
    /// <typeparam name="T">El tipo del valor devuelto por la operación.</typeparam>
    /// <param name="value">El valor devuelto por la operación.</param>
    /// <param name="code">Indica si el código está habilitado.</param>
    /// <param name="message">El mensaje descriptivo del resultado exitoso.</param>
    public class ResultSuccess<T>(T? value, bool code, string message)
    {
        /// <summary>
        /// Gets or sets the response value associated with the operation.
        /// </summary>
        public T? Response { get; set; } = value;

        /// <summary>
        /// Gets or sets a value indicating whether the code is enabled for the successful result.
        /// </summary>
        public bool Code { get; set; } = code;

        /// <summary>
        /// Gets or sets the descriptive message for the successful result.
        /// </summary>
        public string Message { get; set; } = message;

    }
}
