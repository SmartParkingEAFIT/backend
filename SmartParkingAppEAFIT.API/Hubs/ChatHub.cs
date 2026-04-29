// <copyright file="ChatHub.cs" company="Universidad EAFIT">
// Copyright (c) Universidad EAFIT. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.SignalR;

namespace SmartParkingAppEAFIT.API.Hubs
{
    /// <summary>
    /// Hub de SignalR para manejar la comunicación en tiempo real entre el servidor y los clientes.
    /// </summary>
    public class ChatHub : Hub
    {
        /// <summary>
        /// Metodo para enviar un mensaje a todos los clientes conectados al hub. Este método puede ser llamado desde
        /// el cliente para enviar mensajes al servidor,
        /// y el servidor luego retransmitirá esos mensajes a todos los clientes conectados.
        /// </summary>
        /// <param name="message">Mensaje que se enviará a todos los clientes conectados.</param>
        /// <returns>Retorna una tarea que representa la operación asincrónica.</returns>
        public async Task SendMessage(string message)
        {
            Console.WriteLine(message);

            await this.Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}
