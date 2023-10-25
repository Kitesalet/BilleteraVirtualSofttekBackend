using BilleteraVirtualSofttekBack.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BilleteraVirtualSofttekBack.Models.Entities
{
    /// <summary>
    /// Represents a financial transaction.
    /// </summary>
    public class Transaction : BaseEntity
    {
        /// <summary>
        /// The amount of money involved in the transaction.
        /// </summary>
        [Required]
        public decimal Amount { get; set; }

        /// <summary>
        /// The type of the transaction.
        /// </summary>
        [Required]
        public TransactionType Type { get; set; }

        /// <summary>
        /// The concept for the transaction.
        /// </summary>
        public string Concept { get; set; }

        /// <summary>
        /// The ID of the client associated with this transaction.
        /// </summary>
        [ForeignKey("Client")]
        public int ClientId { get; set; }

        /// <summary>
        /// The ID of the source account involved in the transaction.
        /// </summary>
        public int SourceAccountId { get; set; }

        /// <summary>
        /// The ID of the destination account involved in the transaction.
        /// </summary>
        public int DestinationAccountId { get; set; }

        /// <summary>
        /// The source account related to this transaction.
        /// </summary>
        public virtual BaseAccount? SourceAccount { get; set; }

        /// <summary>
        /// The destination account related to this transaction.
        /// </summary>
        public virtual BaseAccount? DestinationAccount { get; set; }

        /// <summary>
        /// The client associated with this transaction.
        /// </summary>
        public virtual Client Client { get; set; }
    }
}
