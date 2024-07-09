using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NZWalks.API.Entities
{
    [Table("Regions")]
    public class Region
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("code")]
        public string Code { get; set; }

        [Column("region_image_url")]
        public string? RegionImageUrl { get; set; }

        [InverseProperty("Region")]
        public virtual ICollection<Walk> Walk { get; set; }
    }
}
