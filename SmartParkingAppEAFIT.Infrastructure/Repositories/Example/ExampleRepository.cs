namespace SmartParkingAppEAFIT.Infrastructure.Repositories.Example
{
    using System;
    using SmartParkingAppEAFIT.Domain.Interfaces.Examples;
    using SmartParkingAppEAFIT.Infrastructure.Data;

    /// <summary>
    /// Clase de ejemplo que implementa la interfaz IExampleRepository.
    /// </summary>
    public class ExampleRepository(DataBaseContext dataBaseContext) : IExampleRepository
    {
        /// <summary>
        /// Obtiene datos de ejemplo desde el repositorio.
        /// </summary>
        /// <returns>Una cadena de texto con los datos de ejemplo.</returns>
        /// <exception cref="Exception">Se lanza cuando ocurre un error al consultar la base de datos.</exception>
        public async Task<string> GetExampleData()
        {
            try
            {
                // Consultas a la base de datos

                await Task.Delay(100); // Simulación de una operación asincrónica, como una consulta a la base de datos.

                return "Example data from repository";
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
