using System.ComponentModel.DataAnnotations;

namespace BilleteraVirtualSofttekBack.Models.DTOs.Client
{
    public class ClientLoginDto
    {

        public string Name { get; set; }

        public string Email { get; set; }

        public string Token { get; set; }


    }
}
