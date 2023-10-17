using BilleteraVirtualSofttekBack.Models.Entities;

namespace BilleteraVirtualSofttekBack.Models.Accounts
{
    public sealed class PesoAccount : FiduciaryAccount
    {

        public override void Deposit(decimal amount)
        {
            throw new NotImplementedException();
        }

        public override void Extract(decimal amount)
        {
            throw new NotImplementedException();
        }

        public override void Transfer(Account toAccount, decimal amount)
        {
            throw new NotImplementedException();
        }
    }
}
