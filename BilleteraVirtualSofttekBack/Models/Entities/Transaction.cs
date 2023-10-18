using BilleteraVirtualSofttekBack.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BilleteraVirtualSofttekBack.Models.Entities
{
    public class Transaction : BaseEntity
    {
            [Required]
            public decimal Amount { get; set; }

            [Required]
            public TransactionType Type { get; set; }

            [Required]
            public string Concept { get; set; }



            [ForeignKey("Client")]
            public int ClientId { get; set; }
            public int SourceAccountId { get; set; }
            public int DestinationAccountId { get; set; }
            public virtual BaseAccount SourceAccount { get; set; }
            public virtual BaseAccount DestinationAccount { get; set; }
            public virtual Client Client { get;set; }


    }
}
