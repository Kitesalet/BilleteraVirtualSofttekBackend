using BilleteraVirtualSofttekBack.Models.Enums;

namespace BilleteraVirtualSofttekBack.Models.DTOs.Account
{
    public class AccountUpdateDto
    {

        public string UUID { get; set; }
        public int AccountNumber { get; set; }
        public int CBU { get; set; }
        public string? Alias { get; set; }
        public int AccountId { get; set; }
        public decimal Balance { get; set; } = 0;
        public AccountType Type { get; set; }
        public int ClientId { get; set; }
    }
}
