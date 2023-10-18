using BilleteraVirtualSofttekBack.Models.Entities;
using BilleteraVirtualSofttekBack.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace BilleteraVirtualSofttekBack.Models.Accounts
{
    public sealed class CryptoAccount : BaseAccount
    {
        
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

            if (toAccount.Type == AccountType.Crypto)
            {
                //Same type of account, same rates
                this.Extract(amount);
                toAccount.Deposit(amount);

            }
            else if (toAccount.Type == AccountType.Dollar)
            {

                //This crypto value has been hardcoded to 100 dollars

                //Dollars to extract
                this.Extract(amount);

                //Dollars to deposit
                decimal newDollar = amount * 100;
                toAccount.Deposit(newDollar);

            }
            else
            {

                throw new Exception("Invalid account type");

            }

        }
    }
}
