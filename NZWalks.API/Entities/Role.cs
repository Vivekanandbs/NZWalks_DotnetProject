using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NZWalks.API.Entities
{
    [Table("role")]
    public class Role
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("role_name")]
        public string RoleName { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("is_active")]
        public bool IsActive { get; set; }

        [Column("is_deleted")]
        public bool IsDeleted { get; set; }

        [Column("date_created")]
        public DateTime CreatedDate { get; set; }

        [Column("date_modified")]
        public DateTime ModifiedDate { get; set; }

        [InverseProperty("Role")]
        public virtual ICollection<RolePrivilage> RolePrivilage { get; set; }

        [InverseProperty("Role")]
        public virtual ICollection<UserRoleMapping> UserRoleMapping { get; set; }
    }
}
