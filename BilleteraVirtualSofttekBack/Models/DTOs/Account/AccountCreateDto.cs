using BilleteraVirtualSofttekBack.Models.Enums;

namespace BilleteraVirtualSofttekBack.Models.DTOs.Account
{
    public class AccountCreateDto
    {
        public string? Alias { get; set; }
        public AccountType Type { get; set; }
        public int ClientId { get; set; }
    }
}
