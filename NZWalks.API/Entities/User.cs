using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NZWalks.API.Entities
{
    [Table("User")]
    public class User
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("user_name")]
        public string UserName { get; set; }

        [Column("password")]
        public string Password { get; set; }

        [Column("password_salt")]
        public string PasswordSalt { get; set; }

        [Column("is_active")]
        public bool IsActive { get; set; }

        [Column("is_deleted")]
        public bool IsDeleted { get; set; }

        [Column("date_created")]
        public DateTime CreatedDate { get; set; }

        [Column("date_modified")]
        public DateTime ModifiedDate { get; set; }

        [Column("user_type_id")]
        public int UserTypeId { get; set; }

        [ForeignKey("UserTypeId")]
        [InverseProperty("User")]
        public virtual UserType UserType { get; set; }

        [InverseProperty("User")]
        public virtual ICollection<UserRoleMapping> UserRoleMapping { get; set; }
    }
}
