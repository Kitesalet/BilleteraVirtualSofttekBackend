using BilleteraVirtualSofttekBack.Models.Entities;
using BilleteraVirtualSofttekBack.Models.Enums;

namespace BilleteraVirtualSofttekBack.Models.Entities.Accounts
{
    public sealed class PesoAccount : FiduciaryAccount
    {
        public override void Transfer(BaseAccount toAccount, decimal amount)
        {

            if (toAccount.Type == AccountType.Crypto)
            {
                throw new Exception("Invalid account");
            }
            else if (toAccount.Type == AccountType.Dollar)
            {

                //Dollar value is hardcoded to 500 pesos

                //Pesos to extract
                Extract(amount);

                //Dollars to deposit
                decimal newDollar = amount / 500;
                toAccount.Deposit(newDollar);

            }
            else
            {
                //Same type of account, same rates
                Extract(amount);
                toAccount.Deposit(amount);
            }

        }

    }
}
