using BilleteraVirtualSofttekBack.Models.Entities;

namespace BilleteraVirtualSofttekBack.Models.Accounts
{
    public abstract class FiduciaryAccount : BaseAccount
    {
        public int CBU { get; set; }
        public int AccountNumber { get; set; }
        public string Alias { get; set; }

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
