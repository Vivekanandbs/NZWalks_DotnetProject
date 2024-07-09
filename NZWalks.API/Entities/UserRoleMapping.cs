using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NZWalks.API.Entities
{
    [Table("userRoleMapping")]
    public class UserRoleMapping
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("user_id")]
        public Guid UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty("UserRoleMapping")]
        public User User { get; set; }

        [Column("role_id")]
        public Guid RoleId { get; set; }

        [ForeignKey(nameof(RoleId))]
        [InverseProperty("UserRoleMapping")]
        public Role Role { get; set; }
    }
}
