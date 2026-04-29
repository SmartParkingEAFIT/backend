// <copyright file="ExampleDTO.cs" company="Universidad EAFIT">
// Copyright (c) Universidad EAFIT. All rights reserved.
// </copyright>

namespace SmartParkingAppEAFIT.Application.DTOs.Examples
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Represents an example data transfer object.
    /// </summary>
    public class ExampleDTO
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        required public string Name { get; set; }

        /// <summary>
        /// Gets or sets the age.
        /// </summary>
        required public int Age { get; set; } = 0;
    }
}
