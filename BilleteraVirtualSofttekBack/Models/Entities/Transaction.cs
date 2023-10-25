using BilleteraVirtualSofttekBack.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BilleteraVirtualSofttekBack.Models.Entities
{
    /// <summary>
    /// Represents a financial transaction.
    /// </summary>
    /// 

    [Table("transaction")]
    public class Transaction : BaseEntity
    {
        /// <summary>
        /// The amount of money involved in the transaction.
        /// </summary>

        [Required]
        [Column("transaction_amount")]
        public decimal Amount { get; set; }

        /// <summary>
        /// The type of the transaction.
        /// </summary>
        [Required]
        [Column("transaction_type")]
        public TransactionType Type { get; set; }


        /// <summary>
        /// The concept for the transaction.
        /// </summary>
        
        [Required]
        [Column("transaction_concept")]
        public TransactionConcept Concept { get; set; }

        /// <summary>
        /// The ID of the client associated with this transaction.
        /// </summary>
        
        [Required]
        [ForeignKey("Client")]
        [Column("transaction_client")]
        public int ClientId { get; set; }

        /// <summary>
        /// The ID of the source account involved in the transaction.
        /// </summary>

        [Required]
        [Column("transaction_source_account")]
        public int SourceAccountId { get; set; }

        /// <summary>
        /// The ID of the destination account involved in the transaction.
        /// </summary>
       
        [Required]
        [Column("transaction_destination_account")]
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
