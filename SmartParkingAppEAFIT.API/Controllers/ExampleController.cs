using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using SmartParkingAppEAFIT.Application.Commons;
using SmartParkingAppEAFIT.Application.Commons.Messages;
using SmartParkingAppEAFIT.Application.DTOs.Examples;
using SmartParkingAppEAFIT.Domain.Commons.Results;
using SmartParkingAppEAFIT.Domain.Interfaces.Examples;
using SmartParkingAppEAFIT.Shared.Extensions;

namespace SmartParkingAppEAFIT.API.Controllers
{
    /// <param name="exampleService">Servicio de ejemplo para manejar la lógica de negocio relacionada con los ejemplos.</param>
    /// <param name="exampleValidator">Validador para asegurar que los datos de entrada cumplen con las reglas definidas.</param>
    /// <summary>
    /// Controlador de ejemplo para demostrar la estructura y el uso de servicios y validadores en una API RESTful.
    /// </summary>
    [Route("api/examples")]
    [ApiController]
    public class ExampleController(IExampleService exampleService, IValidator<ExampleDTO> exampleValidator) : ControllerBase
    {
        /// <param name="exampleDto">DTO que contiene los datos necesarios para crear un nuevo ejemplo.
        /// Debe cumplir con las reglas de validación definidas en el validador.
        /// </param>
        /// <returns>Devuelve un IActionResult que representa el resultado de la operación.
        /// Puede ser un resultado exitoso con los datos del ejemplo creado o un error de validación si los datos de entrada no son válidos.
        /// </returns>
        /// <summary>
        /// Metodo para crear un nuevo ejemplo. Valida el DTO de entrada y devuelve el resultado de la operación.
        /// </summary>
        [Route("data")]
        [HttpPost]
        public async Task<IActionResult> CreateExample([FromBody] ExampleDTO exampleDto)
        {
            var validationResult = await exampleValidator.ValidateAsync(exampleDto);

            if (!validationResult.IsValid)
            {
                return ResultErrorExtensionService.ErrorEventArgs<ResultError>(ResultErrorType.Validation, ValidationMessages.RequestBodyInvalid).ToActionResult(this);
            }

            var createdExampleSimpleString = await exampleService.GetExampleValue();

            var createdExampleResultResponse = await exampleService.GetExampleResult();

            return createdExampleResultResponse.ToActionResult(this);
        }
    }
}
