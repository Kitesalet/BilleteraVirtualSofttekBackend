using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BilleteraVirtualSofttekBack.Models.Entities
{

    /// <summary>
    /// Represents a base entity.
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>
        /// A PK for the entity.
        /// </summary>
        [Key]
        [Column("id")]
        public int Id { get; set; }

        /// <summary>
        /// The date when this entity was created.
        /// </summary>
        [Required]
        [Column("created_date")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        /// <summary>
        /// The date when this entity was deleted.
        /// </summary>
        [Column("deleted_date")]
        public DateTime? DeletedDate { get; set; } = null;

        /// <summary>
        /// The date when this entity was modified.
        /// </summary>
        [Column("modified_date")]
        public DateTime? ModifiedDate { get; set; }
    }
}
