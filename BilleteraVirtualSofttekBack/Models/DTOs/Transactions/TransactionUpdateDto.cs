using BilleteraVirtualSofttekBack.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BilleteraVirtualSofttekBack.Models.Entities
{
    public class TransactionUpdateDto
    {
            public int Id { get; set; }
            public decimal Amount { get; set; }
            public TransactionType Type { get; set; }
            public string Concept { get; set; }
            public int ClientId { get; set; }
            public int SourceAccountId { get; set; }
            public int DestinationAccountId { get; set; }



    }
}
