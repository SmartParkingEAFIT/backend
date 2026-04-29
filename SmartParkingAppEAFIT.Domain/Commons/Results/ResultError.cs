// <copyright file="ResultError.cs" company="Universidad EAFIT">
// Copyright (c) Universidad EAFIT. All rights reserved.
// </copyright>

namespace SmartParkingAppEAFIT.Domain.Commons.Results
{
    /// <summary>
    /// Specifies the types of errors that can occur when processing a result, such as validation failures,
    /// authentication issues, or server errors.
    /// </summary>
    /// <remarks>Use this enumeration to categorize error results in APIs or business logic, enabling
    /// consumers to handle different error scenarios appropriately. The values correspond to common HTTP status code
    /// categories, facilitating consistent error handling and reporting.</remarks>
    public enum ResultErrorType
    {
        /// <summary>
        /// Resource not found error (HTTP 404).
        /// </summary>
        NotFound = 404,

        /// <summary>
        /// Validation error (HTTP 400).
        /// </summary>
        Validation = 400,

        /// <summary>
        /// Conflict error, typically when a resource already exists (HTTP 409).
        /// </summary>
        Conflict = 409,

        /// <summary>
        /// Unauthorized access, authentication required (HTTP 401).
        /// </summary>
        Unauthorized = 401,

        /// <summary>
        /// Forbidden access, insufficient permissions (HTTP 403).
        /// </summary>
        Forbidden = 403,

        /// <summary>
        /// Internal server error (HTTP 500).
        /// </summary>
        InternalServerError = 500,

        /// <summary>
        /// Business rule violation error (HTTP 422).
        /// </summary>
        BusinessRule = 422,

        /// <summary>
        /// Unexpected error, used for unforeseen issues that don't fit other categories (HTTP 520).
        /// </summary>
        Unexpected = 520,

        /// <summary>
        /// Exception error, used for specific exception cases (HTTP 521).
        /// </summary>
        Exception = 521,
    }

    /// <summary>
    /// Clase que representa un error en el resultado de una operación, proporcionando información sobre el tipo de error y un mensaje descriptivo.
    /// </summary>
    /// <param name="resultErrorType">El tipo de error que ocurrió.</param>
    /// <param name="message">El mensaje descriptivo del error.</param>
    public class ResultError(ResultErrorType resultErrorType, string message)
    {
        /// <summary>
        /// Gets the type of error code associated with the result.
        /// </summary>
        public ResultErrorType ErrorCodeType { get; init; } = resultErrorType;

        /// <summary>
        /// Gets a value indicating whether the code is enabled.
        /// </summary>
        public bool Code { get; init; } = false;

        /// <summary>
        /// Gets the message content associated with this instance.
        /// </summary>
        public string Message { get; init; } = message;
    }
}
