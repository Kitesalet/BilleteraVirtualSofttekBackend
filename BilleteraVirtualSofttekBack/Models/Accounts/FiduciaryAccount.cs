using BilleteraVirtualSofttekBack.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace BilleteraVirtualSofttekBack.Models.Accounts
{
    public abstract class FiduciaryAccount : BaseAccount
    {

        [Column("account_date")]
        public int CBU { get; set; }

        [Column("account_number")]
        public int AccountNumber { get; set; }

        [Column("account_alias")]
        public string Alias { get; set; }

        public override void Deposit(decimal amount)
        {
            this.Balance = amount + this.Balance;
        }

        public override void Extract(decimal amount)
        {
            this.Balance -= amount;
        }

        public override void Transfer(BaseAccount toAccount, decimal amount)
        {
            this.Extract(amount);
            toAccount.Deposit(amount);
        }

    }
}
