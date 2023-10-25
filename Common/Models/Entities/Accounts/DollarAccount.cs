using BilleteraVirtualSofttekBack.Models.Entities;
using BilleteraVirtualSofttekBack.Models.Enums;

namespace BilleteraVirtualSofttekBack.Models.Entities.Accounts
{
    public sealed class DollarAccount : FiduciaryAccount
    {


        /// <inheritdoc/>

        public override void Transfer(BaseAccount toAccount, decimal amount)
        {

            if (toAccount.Type == AccountType.Crypto)
            {
                //This crypto value has been hardcoded to 100 dollars

                //Dollars to extract
                Extract(amount);

                //Dollars to deposit
                decimal newCrypto = amount / 100;
                toAccount.Deposit(newCrypto);


            }
            else if (toAccount.Type == AccountType.Dollar)
            {

                //Same type of account, same rates
                Extract(amount);
                toAccount.Deposit(amount);

            }
            else
            {
                //Dollar value is hardcoded to 500 pesos

                //Dollars to extract
                Extract(amount);

                //Dollars to deposit
                decimal newPesos = amount * 400;
                toAccount.Deposit(newPesos);
            }

        }

    }
}
