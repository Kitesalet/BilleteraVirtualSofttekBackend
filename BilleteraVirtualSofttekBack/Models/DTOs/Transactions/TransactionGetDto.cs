using BilleteraVirtualSofttekBack.Models.Entities;
using BilleteraVirtualSofttekBack.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace BilleteraVirtualSofttekBack.Models.DTOs.Transactions
{
    public class TransactionGetDto
    { 
        public decimal Amount { get; set; }

        public string Type { get;set; }
        public int DestinationAccountId { get; set; }

        public int DestinationAccountUUID { get; set; }

        public int DestionationAccountCBU { get; set; }

        public int SourceAccountId { get; set; }

        public int SourceAccountUUID { get; set; }

        public int SourceAccountCBU { get; set; }

        public string Concept { get; set; }

        public string 

    }
}
