using BilleteraVirtualSofttekBack.Models.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BilleteraVirtualSofttekBack.Models.DTOs.Account
{
    public class AccountGetDto
    {
        public int Id { get; set; }
        public string UUID { get; set; }
        public int AccountNumber { get; set; }
        public int CBU { get; set; }
        public string? Alias { get; set; }
        public decimal Balance { get; set; }
        public string Type { get; set; }
        public int ClientId { get; set; }

    }
}
