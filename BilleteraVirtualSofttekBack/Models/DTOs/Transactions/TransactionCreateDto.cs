using BilleteraVirtualSofttekBack.Models.Enums;

namespace BilleteraVirtualSofttekBack.Models.DTOs.Transactions
{
    public class TransactionCreateDto
    {

        public decimal Amount { get; set; }
        public TransactionType Type { get; set; }
        public TransactionConcept Concept { get; set; }
        public int ClientId { get; set; }
        public int SourceAccountId { get; set; }
        public int DestinationAccountId { get; set; }


    }
}
