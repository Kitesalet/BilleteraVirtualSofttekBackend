using BilleteraVirtualSofttekBack.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace BilleteraVirtualSofttekBack.Models.Entities.Accounts
{
    /// <summary>
    /// Represents a fiduciary account.
    /// </summary>
    public abstract class FiduciaryAccount : BaseAccount
    {
        /// <summary>
        /// The CBU of this account.
        /// </summary>
        [Column("account_cbu")]
        public int CBU { get; set; }

        /// <summary>
        /// The account number for this account.
        /// </summary>
        [Column("account_number")]
        public int AccountNumber { get; set; }

        /// <summary>
        /// An alias for the account.
        /// </summary>
        [Column("account_alias")]
        public string Alias { get; set; }

        /// <inheritdoc/>
        public override void Deposit(decimal amount)
        {
            Balance = amount + Balance;
        }

        /// <inheritdoc/>
        public override void Extract(decimal amount)
        {
            Balance -= amount;
        }

        /// <inheritdoc/>
        public override void Transfer(BaseAccount toAccount, decimal amount)
        {
            Extract(amount);
            toAccount.Deposit(amount);
        }
    }
}
