using BilleteraVirtualSofttekBack.Models.DTOs.Client;
using BilleteraVirtualSofttekBack.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BilleteraVirtualSofttekBack.Models.Interfaces.RepoInterfaces
{
    /// <summary>
    /// This interface defines extra repository operations related to the Transaction entity.
    /// </summary>
    public interface ITransactionRepository : IRepository<Transaction>
    {

        /// <summary>
        /// Gets a collection of transactions associated with a specific account.
        /// </summary>
        /// <param name="accountId">The ID of the account to get transactions for.</param>
        /// <returns>Returns a collection of transactions associated with the specified account.</returns>
        public Task<IEnumerable<Transaction>> GetTransactionByAccount(int accountId);


    }
}