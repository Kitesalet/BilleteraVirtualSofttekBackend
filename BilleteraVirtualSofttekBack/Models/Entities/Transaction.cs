using BilleteraVirtualSofttekBack.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace BilleteraVirtualSofttekBack.Models.Entities
{
    public class Transaction : BaseEntity
    {
            public decimal Amount { get; set; }
            public DateTime CreationDate { get; set; }
            public TransactionType Type { get; set; }
            public string Concept { get; set; }

            [ForeignKey("ClientId")]
            public int ClientId { get; set; }

            [ForeignKey("SourceAccount")]
            public int SourceAccountId { get; set; }

            [ForeignKey("DestinationAccount")]
            public int DestinationAccountId { get; set; }
            public virtual BaseAccount SourceAccount { get; set; }
            public virtual BaseAccount DestinationAccount { get; set; }
            public virtual Client Client { get;set; }


    }
}
