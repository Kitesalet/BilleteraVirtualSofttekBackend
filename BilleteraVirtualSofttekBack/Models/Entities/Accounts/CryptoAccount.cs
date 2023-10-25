using BilleteraVirtualSofttekBack.Models.Entities;
using BilleteraVirtualSofttekBack.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BilleteraVirtualSofttekBack.Models.Entities.Accounts
{
    /// <summary>
    /// Represents a crypto account.
    /// </summary>
    public sealed class CryptoAccount : BaseAccount
    {
        /// <summary>
        /// The UUID of this crypto account.
        /// </summary>

        [Column("accound_uuid")]
        public Guid UUID { get; set; }

        /// <inheritdoc/>

        public override void Deposit(decimal amount)
        {
            Balance = amount + Balance;
        }

        /// <inheritdoc/>

        public override void Extract(decimal amount)
        {
            Balance = Balance - amount;
        }

        /// <inheritdoc/>

        public override void Transfer(BaseAccount toAccount, decimal amount)
        {

            if (toAccount.Type == AccountType.Crypto)
            {
                //Same type of account, same rates
                Extract(amount);
                toAccount.Deposit(amount);

            }
            else if (toAccount.Type == AccountType.Dollar)
            {

                //This crypto value has been hardcoded to 100 dollars

                //Dollars to extract
                Extract(amount);

                //Dollars to deposit
                decimal newDollar = amount * 100;
                toAccount.Deposit(newDollar);

            }
            else
            {

                throw new Exception("Invalid account type");

            }

        }
    }
}
