using BilleteraVirtualSofttekBack.Models.Entities;

namespace BilleteraVirtualSofttekBack.Models.DTOs.Client
{
    public class ClientUpdateDto : BaseEntity
    {

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }


    }
}
