using BilleteraVirtualSofttekBack.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BilleteraVirtualSofttekBack.Models.Entities
{
    /// <summary>
    /// Represents a base account with common properties and methods.
    /// </summary>

    [Table("account")]
    public abstract class BaseAccount : BaseEntity
    {
        /// <summary>
        /// The account balance.
        /// </summary>
        [Required]
        [Column("account_balance", TypeName = "decimal(18,2)")]
        public decimal Balance { get; set; } = 0;

        /// <summary>
        /// The type of account.
        /// </summary>
        [Required]
        [Column("account_type")]
        public AccountType Type { get; set; }

        /// <summary>
        /// The client who owns this account.
        /// </summary>
        public Client Client { get; set; }

        /// <summary>
        /// The unique identifier of the client who owns this account.
        /// </summary>
        [ForeignKey("Client")]
        [Column("client_id")]
        public int ClientId { get; set; }

        /// <summary>
        /// Adds money to the account.
        /// </summary>
        public abstract void Deposit(decimal amount);

        /// <summary>
        /// Removes money from the account.
        /// </summary>
        public abstract void Extract(decimal amount);

        /// <summary>
        /// Transfers money from this account to another account.
        /// </summary>
        public abstract void Transfer(BaseAccount toAccount, decimal amount);
    }
}
