// <copyright file="IExampleService.cs" company="Universidad EAFIT">
// Copyright (c) Universidad EAFIT. All rights reserved.
// </copyright>

namespace SmartParkingAppEAFIT.Domain.Interfaces.Examples
{
    using SmartParkingAppEAFIT.Domain.Commons.Results;

    /// <summary>
    /// Defines the contract for example service operations.
    /// </summary>
    public interface IExampleService
    {
        /// <summary>
        /// Gets an example string value.
        /// </summary>
        /// <returns>A string representing the example value.</returns>
        public Task<string> GetExampleValue();

        /// <summary>
        /// Gets an example result containing a string value.
        /// </summary>
        /// <returns>A <see cref="Result{T}"/> containing a string value.</returns>
        public Task<Result<string>> GetExampleResult();
    }
}
