using BilleteraVirtualSofttekBack.Models.DTOs.Client;
using BilleteraVirtualSofttekBack.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BilleteraVirtualSofttekBack.Models.Interfaces.RepoInterfaces
{
    /// <summary>
    /// This interface defines extra repository operations related to the Usuario entity.
    /// </summary>
    public interface IClientRepository : IRepository<Client>
    {
        /// <summary>
        /// Evaluates if a client exists and check its credentials.
        /// </summary>
        /// <param name="dto">AuthenticateDTO.</param>
        /// <returns> 
        ///  A Usuario instance if the authentication is successful
        ///  A null value if the authentication is not successful
        /// </returns>
        public Task<Client?> AuthenticateCredentials(ClientAuthenticateDto dto);

        /// <summary>
        /// Evaluates the existence of a client.
        /// </summary>
        /// <param name="dto">AuthenticateDTO.</param>
        /// <returns> 
        /// A true value if the query is a success
        /// A false value if it fails
        /// </returns>
        Task<bool> ClientExists(ClientCreateDto dto);

        /// <summary>
        /// Evaluates the existence of an email.
        /// </summary>
        /// <param name="dto">A string containing the email of the user to check.</param>
        /// <returns> 
        /// A true value if the query is a success
        /// A false value if it fails
        /// </returns>
        Task<bool> VerifyExistingEmail(string email);


    }
}