using Newtonsoft.Json;

namespace NZWalks.API.Models
{
    public class RegionDto
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("region_image_url")]
        public string? RegionImageUrl { get; set; }
    }
}
