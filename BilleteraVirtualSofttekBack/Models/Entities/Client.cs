using System.ComponentModel.DataAnnotations;

namespace BilleteraVirtualSofttekBack.Models.Entities
{
    public class Client : BaseEntity
    {

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }


        public List<Account> Accounts { get; set; }

    }
}
