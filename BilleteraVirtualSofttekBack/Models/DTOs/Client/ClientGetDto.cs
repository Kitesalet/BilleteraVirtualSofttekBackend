using BilleteraVirtualSofttekBack.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BilleteraVirtualSofttekBack.Models.DTOs.Client
{
    public class ClientGetDto 
    {

        public string Name { get; set; }

        public string Email { get; set; }

        public string Role { get; set; }

        public int Id { get; set; }


    }
}
