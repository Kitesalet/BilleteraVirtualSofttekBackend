using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BilleteraVirtualSofttekBack.Models.Entities
{
    public class Client : BaseEntity
    {

        [Required]
        [Column("client_name")]
        public string Name { get; set; }

        [Required]
        [Column("client_email")]
        public string Email { get; set; }

        [Required]
        [Column("client_password")]
        public string Password { get; set; }


        public List<Transaction> Transactions { get; set; }
        public List<BaseAccount> Accounts { get; set; }

    }
}
