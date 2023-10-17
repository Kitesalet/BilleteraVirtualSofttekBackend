using BilleteraVirtualSofttekBack.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace BilleteraVirtualSofttekBack.Models.Entities
{
    public abstract class Account : BaseEntity
    {

            public int AccountId { get; set; }
            public decimal Balance { get; set; }
            public AccountType Type { get; set; }


            public Client Client { get; set; }

            [ForeignKey("Client")]
            public int ClientId { get; set; }

            public abstract void Deposit(decimal amount);

            public abstract void Extract(decimal amount);

            public abstract void Transfer(Account toAccount, decimal amount);
        

    }
}
