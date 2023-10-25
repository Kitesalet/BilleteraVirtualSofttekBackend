using BilleteraVirtualSofttekBack.Models.DTOs.Account;
using BilleteraVirtualSofttekBack.Models.DTOs.Transactions;

namespace BilleteraVirtualSofttekBack.Models.Interfaces.ServiceInterfaces
{


        /// <summary>
        /// This interface defines the service for defining and using AccountDtos and its logic.
        /// </summary>
        public interface IAccountService
        {
            /// <summary>
            /// Gets a collection of Account data that hasnt been soft deleted with pagination.
            /// </summary>
            /// <returns>All of the AccountGetDto entities.</returns>
            Task<IEnumerable<AccountGetDto>> GetAllAccountsByClientAsync(int id);

            /// <summary>
            /// Gets Account data by its id.
            /// </summary>
            /// <param name="id">An int.</param>
            /// <returns>One of the Account entities as a AccountGetDto.</returns>
            Task<AccountGetDto> GetAccountByIdAsync(int id);

            /// <summary>
            /// Creates a Account.
            /// </summary>
            /// <param name="AccountDto">An userCreateDto.</param>
            /// <returns>A boolean value based on the creation of the Account.
            /// </returns>
            Task<bool> CreateAccountAsync(AccountCreateDto AccountDto);

            /// <summary>
            /// Updates the Account data that hasnt been soft deleted.
            /// </summary>
            /// <param name="userDto">A AccountUpdateDto.</param>
            /// <returns>A boolean value based on the update of the Account.</returns>
            Task<bool> UpdateAccount(AccountUpdateDto userDto);

            /// <summary>
            /// Deletes a Account based on its id, first it soft deletes it.
            /// </summary>
            /// <param name="id">An int.</param>
            /// <returns>A boolean value based on the Deletion of the Account, true if it was soft or hard deleted.</returns>
            Task<bool> DeleteAccountAsync(int id);

            /// <summary>
            /// Updates an account adding money to it in the effect of a deposit.
            /// </summary>
            /// <param name="transactionDTO">A AccountDepositDto that has the information of the account to deposit</param>
            /// <returns>A boolean value based on the deposit of an account.</returns>
            public Task<bool> DepositAsync(AccountDepositDto transactionDTO);

            /// <summary>
            /// Updates twi accounts transfering money from one account to the other.
            /// </summary>
            /// <param name="transactionDTO">A transferDto that has the information of the account transfer money into and the origin account as well.</param>
            /// <returns>A boolean value based on the transfer between two account.</returns>
            public Task<bool> TransferAsync(TransferDto transactionDTO);


            /// <summary>
            /// Updates an account withdrawing money out of it in the effect of an extraction.
            /// </summary>
            /// <param name="transactionDTO">AccountExtractDto that has the information of the account to withdraw</param>
            /// <returns>A boolean value based on the extraction of an account.</returns>
            public Task<bool> ExtractAsync(AccountExtractDto transactionDTO);

            /// <summary>
            /// Gets a list of accounts with pagination support.
            /// </summary>
            /// <param name="page">The page number.</param>
            /// <param name="units">The number of accounts per page.</param>
            /// <returns>Returns a list of accounts.</returns>
            public Task<List<AccountGetDto>> GetAllAccounts(int page, int units);


        }


}
