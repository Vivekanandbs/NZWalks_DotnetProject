using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.Entities
{
    public class RolePrivilage
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("role_privilage_name")]
        public string RolePrivilageName { get; set; }

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

        [Column("role_id")]
        public Guid? RoleId { get; set; }

        [ForeignKey(nameof(RoleId))]
        [InverseProperty("RolePrivilage")]
        public Role? Role { get; set; }
    }
}
