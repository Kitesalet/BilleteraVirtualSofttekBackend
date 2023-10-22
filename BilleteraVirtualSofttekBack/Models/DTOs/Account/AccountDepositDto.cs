namespace BilleteraVirtualSofttekBack.Models.DTOs.Account
{
    public class AccountDepositDto
    {
        public int Id { get; set; }
        public decimal Amount { get; set; } 

        public int ClientId { get; set; }

    }
}
