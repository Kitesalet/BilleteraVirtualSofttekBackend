

using BilleteraVirtualSofttekBack.Models.DTOs.Client;

namespace IntegradorSofttekImanol.Models.Interfaces.ServiceInterfaces
{
    /// <summary>
    /// This interface defines the service for defining and using ClientDtos and its logic.
    /// </summary>
    public interface IClientService
    {
        /// <summary>
        /// Gets a collection of client data that hasnt been soft deleted with pagination.
        /// </summary>
        /// <returns>All of the ClientGetDto entities.</returns>
        Task<IEnumerable<ClientGetDto>> GetAllClientsAsync(int page, int units);

        /// <summary>
        /// Gets client data by its id.
        /// </summary>
        /// <param name="id">An int.</param>
        /// <returns>One of the client entities as a ClientGetDto.</returns>
        Task<ClientGetDto> GetClientByIdAsync(int id);

        /// <summary>
        /// Creates a client.
        /// </summary>
        /// <param name="clientDto">An userCreateDto.</param>
        /// <returns>A boolean value based on the creation of the client.
        /// </returns>
        Task<bool> CreateClientAsync(ClientCreateDto clientDto);

        /// <summary>
        /// Updates the client data that hasnt been soft deleted.
        /// </summary>
        /// <param name="userDto">A clientUpdateDto.</param>
        /// <returns>A boolean value based on the update of the client.</returns>
        Task<bool> UpdateClient(ClientUpdateDto userDto);

        /// <summary>
        /// Deletes a client based on its id, first it soft deletes it.
        /// </summary>
        /// <param name="id">An int.</param>
        /// <returns>A boolean value based on the Deletion of the client, true if it was soft or hard deleted.</returns>
        Task<bool> DeleteClientAsync(int id);
    }
}
