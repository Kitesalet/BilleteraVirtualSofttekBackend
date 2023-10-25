using BilleteraVirtualSofttekBack.Models.DTOs.Transactions;
using BilleteraVirtualSofttekBack.Models.Entities;

namespace IntegradorSofttekImanol.Models.Interfaces.ServiceInterfaces
{
    /// <summary>
    /// This interface defines the service for defining and using TransactionDtos and its logic.
    /// </summary>
    public interface ITransactionService
    {
        /// <summary>
        /// Gets a collection of Transaction data that hasnt been soft deleted with pagination.
        /// </summary>
        /// <returns>All of the TransactionGetMinDto entities.</returns>
        Task<IEnumerable<TransactionGetMinDto>> GetAllTransactionsAsync(int page, int units);

        /// <summary>
        /// Gets Transaction data by its id.
        /// </summary>
        /// <param name="id">An int.</param>
        /// <returns>One of the Transaction entities as a TransactionGetDto.</returns>
        Task<TransactionGetDto> GetTransactionByIdAsync(int id);

        /// <summary>
        /// Gets Transaction data by an account Id
        /// </summary>
        /// <param name="id">An int.</param>
        /// <returns>One of the Transaction entities as a TransactionGetDto.</returns>
        Task<List<TransactionGetDto>> GetTransactionByAccountAsync(int clientId);

        /// <summary>
        /// Creates a Transaction.
        /// </summary>
        /// <param name="transactionDto">An transactionCreateDto.</param>
        /// <returns>A boolean value based on the creation of the Transaction.
        /// </returns>
        Task<bool> CreateTransactionAsync(TransactionCreateDto transactionDto);

        /// <summary>
        /// Updates the Transaction data that hasnt been soft deleted.
        /// </summary>
        /// <param name="transactionDto">A transactionUpdateDto.</param>
        /// <returns>A boolean value based on the update of the Transaction.</returns>
        Task<bool> UpdateTransaction(TransactionUpdateDto userDto);

        /// <summary>
        /// Deletes a Transaction based on its id, first it soft deletes it.
        /// </summary>
        /// <param name="id">An int.</param>
        /// <returns>A boolean value based on the Deletion of the Transaction, true if it was soft or hard deleted.</returns>
        Task<bool> DeleteTransactionAsync(int id);
    }
}
