using BilleteraVirtualSofttekBack.Models.DTOs.Account;
using BilleteraVirtualSofttekBack.Models.Enums;

namespace BilleteraVirtualSofttekBack.Models.DTOs.Transactions
{
    public class TransactionGetMinDto
    {

        public decimal Amount { get; set; }
        public string Type { get; set; }
        public string Concept { get; set; }
        public int SourceAccountId { get; set; }
        public int DestinationAccountId { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
