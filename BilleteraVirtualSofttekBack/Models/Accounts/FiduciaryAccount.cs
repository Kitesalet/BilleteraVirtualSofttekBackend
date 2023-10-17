using BilleteraVirtualSofttekBack.Models.Entities;

namespace BilleteraVirtualSofttekBack.Models.Accounts
{
    public abstract class FiduciaryAccount : Account
    {
        public int CBU { get; set; }
        public int AccountNumber { get; set; }
        public string Alias { get; set; }
        public override void Deposit(decimal amount)
        {
            throw new NotImplementedException();
        }

        public override void Transfer(Account toAccount, decimal amount)
        {
            throw new NotImplementedException();
        }
    }
}
