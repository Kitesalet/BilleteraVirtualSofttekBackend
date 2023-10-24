using BilleteraVirtualSofttekBack.Models.Entities;
using BilleteraVirtualSofttekBack.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace BilleteraVirtualSofttekBack.Models.DTOs.Transactions
{
    public class TransferDto
    { 
        public decimal Amount { get; set; }
        public int DestinationAccountId { get; set; }
        public int OriginAccountId { get; set; }
        public string? Concept { get; set; }

    }
}
