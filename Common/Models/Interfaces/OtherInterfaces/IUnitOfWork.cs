using BilleteraVirtualSofttekBack.DAL.Repositories;
using IntegradorSofttekImanol.DAL.Repositories;

namespace IntegradorSofttekImanol.Models.Interfaces.OtherInterfaces
{
    /// <summary>
    /// This interface defines a unit that manages repositories and databases.
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Gets the repository for Client data.
        /// </summary>
        ClientRepository ClientRepository { get; }

        /// <summary>
        /// Gets the repository for Account data.
        /// </summary>
        AccountRepository AccountRepository { get; }

        /// <summary>
        /// Gets the repository for Transaction data.
        /// </summary>
        TransactionRepository TransactionRepository { get; }

        /// <summary>
        /// Completes and saves the context related to the database.
        /// </summary>
        /// <returns>The number of rows affected by saving the changed of the context.</returns>
        Task<int> Complete();
    }
}
