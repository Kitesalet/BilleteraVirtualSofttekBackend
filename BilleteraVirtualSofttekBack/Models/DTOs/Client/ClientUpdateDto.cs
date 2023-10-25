using BilleteraVirtualSofttekBack.Models.Entities;
using BilleteraVirtualSofttekBack.Models.Enums;

namespace BilleteraVirtualSofttekBack.Models.DTOs.Client
{
    public class ClientUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ClientRole Role { get; set; }

        public string Password { get; set; }


    }
}
