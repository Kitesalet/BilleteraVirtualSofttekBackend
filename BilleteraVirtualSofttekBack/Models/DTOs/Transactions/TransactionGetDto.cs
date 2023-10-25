using BilleteraVirtualSofttekBack.Models.DTOs.Account;
using BilleteraVirtualSofttekBack.Models.Entities;
using BilleteraVirtualSofttekBack.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace BilleteraVirtualSofttekBack.Models.DTOs.Transactions
{
    public class TransactionGetDto
    { 
        public decimal Amount { get; set; }
        public string Type { get; set; }
        public string Concept { get; set; }
        public AccountGetDto SourceAccount { get; set; }
        public AccountGetDto DestinationAccount { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
