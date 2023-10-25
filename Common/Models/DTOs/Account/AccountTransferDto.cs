namespace BilleteraVirtualSofttekBack.Models.DTOs.Account
{
    public class AccountTransferDto
    {
        public decimal Amount { get; set; }
        public int IdOrigin { get; set; }
        public int IdReception { get; set; }

    }
}
