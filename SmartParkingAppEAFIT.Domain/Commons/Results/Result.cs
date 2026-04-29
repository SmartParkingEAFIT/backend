// <copyright file="Result.cs" company="Universidad EAFIT">
// Copyright (c) Universidad EAFIT. All rights reserved.
// </copyright>

namespace SmartParkingAppEAFIT.Domain.Commons.Results
{
    /// <summary>
    /// Clase para representar el resultado de una operación, indicando si fue exitosa o no,
    /// y proporcionando información adicional en caso de error.
    /// </summary>
    public class Result
    {
        /// <summary>
        /// Gets a value indicating whether the operation was successful.
        /// </summary>
        public bool IsSuccess { get; }

        /// <summary>
        /// Gets the error information if the operation failed.
        /// </summary>
        public ResultError? ResultError { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Result"/> class.
        /// </summary>
        /// <param name="isSuccess">Indica si la operación fue exitosa.</param>
        /// <param name="error">Proporciona información sobre el error en caso de que la operación no sea exitosa.</param>
        protected Result(bool isSuccess, ResultError? error)
        {
            this.IsSuccess = isSuccess;

            this.ResultError = error;
        }

        /// <summary>
        /// Creates a successful result.
        /// </summary>
        /// <returns>A new successful <see cref="Result"/> instance.</returns>
        public static Result Success() => new (true, null);

        /// <summary>
        /// Creates a failed result with the specified error.
        /// </summary>
        /// <param name="error">The error information.</param>
        /// <returns>A new failed <see cref="Result"/> instance.</returns>
        public static Result Fail(ResultError error) => new (false, error);
    }

    /// <summary>
    /// Clase que no puede ser heredada y representa el resultado de una operación con un valor de tipo <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">El tipo del valor devuelto por la operación.</typeparam>
    public sealed class Result<T> : Result
    {
        /// <summary>
        /// Gets or sets the successful result value and message.
        /// </summary>
        public ResultSuccess<T> ResultSuccess { get; set; }

        private Result(T? value, string message, bool isSuccess, ResultError? error)
            : base(isSuccess, error)
        {
            this.ResultSuccess = new ResultSuccess<T>(value, isSuccess, message);
        }

        /// <summary>
        /// Creates a successful result with the specified value and message.
        /// </summary>
        /// <param name="value">The value returned by the operation.</param>
        /// <param name="message">The success message.</param>
        /// <returns>A new successful <see cref="Result{T}"/> instance.</returns>
        public static Result<T> Success(T value, string message) => new (value, message, true, null);

        /// <summary>
        /// Creates a failed result with the specified error.
        /// </summary>
        /// <param name="error">The error information.</param>
        /// <returns>A new failed <see cref="Result{T}"/> instance.</returns>
        public static new Result<T> Fail(ResultError error) => new (default, error.Message, false, error);
    }
}
