using BilleteraVirtualSofttekBack.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace BilleteraVirtualSofttekBack.Models.Accounts
{
    public sealed class CryptoAccount : BaseAccount
    {
        [Key]
        public Guid UUID { get; set; }

        public override void Deposit(decimal amount)
        {
            this.Balance = amount + this.Balance;
        }

        public override void Extract(decimal amount)
        {
            this.Balance = amount - this.Balance;
        }

        public override void Transfer(BaseAccount toAccount, decimal amount)
        {
            this.Extract(amount);
            toAccount.Deposit(amount);
        }
    }
}
