using BilleteraVirtualSofttekBack.Models.Enums;

namespace BilleteraVirtualSofttekBack.Models.DTOs.Account
{
    public class AccountCreateDto
    {
        public AccountType Type { get; set; }
        public int ClientId { get; set; }
    }
}
