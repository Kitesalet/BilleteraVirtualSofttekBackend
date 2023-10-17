using BilleteraVirtualSofttekBack.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace BilleteraVirtualSofttekBack.Models.Entities
{
    public class Transaction : BaseEntity
    {
            public decimal Amount { get; set; }
            public DateTime Date { get; set; }
            public TransactionType Type { get; set; }

            [ForeignKey("SourceAccount")]
            public int SourceAccountId { get; set; }

            [ForeignKey("DestinationAccount")]
            public int DestinationAccountId { get; set; }
            public virtual Account SourceAccount { get; set; }
            public virtual Account DestinationAccount { get; set; }


    }
}
