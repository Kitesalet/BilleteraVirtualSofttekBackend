using BilleteraVirtualSofttekBack.Models.DTOs.Account;

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
        }

    
}
