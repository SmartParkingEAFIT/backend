// <copyright file="IExampleRepository.cs" company="Universidad EAFIT">
// Copyright (c) Universidad EAFIT. All rights reserved.
// </copyright>

namespace SmartParkingAppEAFIT.Domain.Interfaces.Examples
{
    /// <summary>
    /// Represents a repository that provides access to example data.
    /// </summary>
    public interface IExampleRepository
    {
        /// <summary>
        /// Gets example data as a string.
        /// </summary>
        /// <returns>A string representing the example data.</returns>
        public Task<string> GetExampleData();
    }
}
