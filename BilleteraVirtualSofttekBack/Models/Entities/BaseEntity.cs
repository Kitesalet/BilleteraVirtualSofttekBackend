using System.ComponentModel.DataAnnotations;

namespace BilleteraVirtualSofttekBack.Models.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }

        public DateTime CreatedDate { get;set; } = DateTime.Now;

        public DateTime? DeletedDate { get; set; } = null;

        public DateTime? ModifiedDate { get;set; }

    }
}
