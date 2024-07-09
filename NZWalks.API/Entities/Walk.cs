using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NZWalks.API.Entities
{
    [Table("Walks")]
    public class Walk
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("length_in_km")]
        public double LengthInKm { get; set; }

        [Column("walk_image_url")]
        public string? WalkImageUrl { get; set; }

        [Column("difficulty_id")]
        public Guid? DifficultyId { get; set; }

        [ForeignKey(nameof(DifficultyId))]
        [InverseProperty("Walk")]
        public Difficulty? Difficulty { get; set; }

        [Column("region_id")]
        public Guid? RegionId { get; set; }

        [ForeignKey(nameof(RegionId))]
        [InverseProperty("Walk")]
        public Region? Region { get; set; }
    }
}
