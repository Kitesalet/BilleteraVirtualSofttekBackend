using BilleteraVirtualSofttekBack.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace BilleteraVirtualSofttekBack.Models.DTOs.Client
{
    public class ClientGetDto : BaseEntity
    {

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }


    }
}
