using BilleteraVirtualSofttekBack.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BilleteraVirtualSofttekBack.Models.Interfaces.RepoInterfaces
{
    /// <summary>
    /// The interface to access to account-related data.
    /// </summary>
    public interface IAccountRepository
    {
        /// <summary>
        /// Get all the accounts associated with a specific client.
        /// </summary>
        /// <param name="clientId">The clients ID for which you want to retrieve accounts.</param>
        /// <returns>Returns a collection of accounts owned by a client identified by their ID.</returns>
        Task<IEnumerable<BaseAccount>> GetAllAccountsByClient(int clientId, int page, int units);

        /// <summary>
        /// Check if a specific CBU number exists.
        /// </summary>
        /// <param name="cbu">The CBU number to verify.</param>
        /// <returns>It returns true if the CBU number exists; if not it returns false.</returns>
        Task<bool> VerifyExistingCBU(int cbu);

        /// <summary>
        /// Check if a specific account number exists.
        /// </summary>
        /// <param name="accountNumber">The account number to verify.</param>
        /// <returns>It returns true if the account number exists, if not, it returns false.</returns>
        Task<bool> VerifyExistingAccountNumber(int accountNumber);

        /// <summary>
        /// Check if a specific alias for an account exists.
        /// </summary>
        /// <param name="alias">The alias to verify.</param>
        /// <returns>It returns true if the alias exists, if not,  it returns false.</returns>
        Task<bool> VerifyExistingAlias(string alias);

        /// <summary>
        /// Check if a specific UUID for an account exists.
        /// </summary>
        /// <param name="alias">The UUID to verify.</param>
        /// <returns>It returns true if the UUID exists, if not, it returns false.</returns>
        Task<bool> VerifyExistingUUID(string UUID);

    }
}
