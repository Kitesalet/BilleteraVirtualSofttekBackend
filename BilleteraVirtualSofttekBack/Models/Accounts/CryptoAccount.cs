using BilleteraVirtualSofttekBack.Models.Entities;

namespace BilleteraVirtualSofttekBack.Models.Accounts
{
    public sealed class CryptoAccount : BaseAccount
    {

        public Guid UUID { get; set; }

        public override void Deposit(decimal amount)
        {
            throw new NotImplementedException();
        }

        public override void Extract(decimal amount)
        {
            throw new NotImplementedException();
        }

        public override void Transfer(BaseAccount toAccount, decimal amount)
        {
            throw new NotImplementedException();
        }
    }
}
