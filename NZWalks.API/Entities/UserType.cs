using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NZWalks.API.Entities
{
    [Table("UserType")]
    public class UserType
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [InverseProperty("UserType")]
        public virtual ICollection<User> User { get; set; }
    }
}
