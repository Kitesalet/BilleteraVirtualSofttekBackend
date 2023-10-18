using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BilleteraVirtualSofttekBack.Models.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("created_date")]
        public DateTime CreatedDate { get;set; } = DateTime.Now;

        [Column("deleted_date")]
        public DateTime? DeletedDate { get; set; } = null;

        [Column("modified_date")]
        public DateTime? ModifiedDate { get;set; }

    }
}
