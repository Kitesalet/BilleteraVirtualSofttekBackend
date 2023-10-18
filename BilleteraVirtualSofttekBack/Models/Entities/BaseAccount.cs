using BilleteraVirtualSofttekBack.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BilleteraVirtualSofttekBack.Models.Entities
{
    [Table("Accounts")]
    public abstract class BaseAccount : BaseEntity
    {

            [Required]
            [Column("account_money", TypeName = "decimal(18,2)")]
            public decimal Balance { get; set; } = 0;
            public AccountType Type { get; set; }


            public Client Client { get; set; }

            [ForeignKey("Client")]
            [Column("client_id")]
            public int ClientId { get; set; }

            public abstract void Deposit(decimal amount);

            public abstract void Extract(decimal amount);

            public abstract void Transfer(BaseAccount toAccount, decimal amount);
        

    }
}
