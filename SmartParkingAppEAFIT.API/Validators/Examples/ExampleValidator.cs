// <copyright file="ExampleValidator.cs" company="Universidad EAFIT">
// Copyright (c) Universidad EAFIT. All rights reserved.
// </copyright>

namespace SmartParkingAppEAFIT.AppService.Convocatorias.Validators.Examples
{
    using FluentValidation;
    using SmartParkingAppEAFIT.Application.DTOs.Examples;

    /// <summary>
    /// Validator for the ExampleDTO class that defines validation rules.
    /// </summary>
    public class ExampleValidator : AbstractValidator<ExampleDTO>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExampleValidator"/> class.
        /// </summary>
        public ExampleValidator()
        {
            // Validate Name property
            this.RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required")
                .MinimumLength(2).WithMessage("Name must be at least 2 characters long")
                .MaximumLength(100).WithMessage("Name cannot exceed 100 characters")
                .Matches("^[a-zA-Z ]+$").WithMessage("Name can only contain letters and spaces");

            // Validate Age property
            this.RuleFor(x => x.Age)
                .GreaterThan(0).WithMessage("Age must be greater than 0")
                .LessThanOrEqualTo(120).WithMessage("Age must be 120 or less");
        }
    }
}
