using BilleteraVirtualSofttekBack.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BilleteraVirtualSofttekBack.Models.Entities
{
    /// <summary>
    /// Represents a client.
    /// </summary>
    /// 

    [Table("client")]
    public class Client : BaseEntity
    {
        /// <summary>
        /// The name of the client.
        /// </summary>
        [Required]
        [Column("client_name")]
        public string Name { get; set; }

        /// <summary>
        /// The email address of the client used as its user identification.
        /// </summary>
        [Required]
        [Column("client_email")]
        public string Email { get; set; }

        /// <summary>
        /// The password associated with the clients account.
        /// </summary>
        [Required]
        [Column("client_password")]
        public string Password { get; set; }

        /// <summary>
        /// The role associated to this client.
        /// </summary>
        [Required]
        [Column("client_role")]
        public ClientRole Role { get; set; }

        /// <summary>
        /// A list of transactions associated with the client.
        /// </summary>
        public List<Transaction> Transactions { get; set; }

        /// <summary>
        /// A list of accounts owned by the client.
        /// </summary>
        public List<BaseAccount> Accounts { get; set; }
    }
}
