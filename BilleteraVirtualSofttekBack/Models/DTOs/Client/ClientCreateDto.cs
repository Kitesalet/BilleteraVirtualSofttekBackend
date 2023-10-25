using BilleteraVirtualSofttekBack.Models.Entities;
using BilleteraVirtualSofttekBack.Models.Enums;

namespace BilleteraVirtualSofttekBack.Models.DTOs.Client
{
    public class ClientCreateDto 
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public ClientRole Role { get; set; }

    }
}
