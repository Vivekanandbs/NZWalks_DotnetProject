using Newtonsoft.Json;

namespace NZWalks.API.Models
{
    public class AddRegionRequestDto
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("region_image_url")]
        public string? RegionImageUrl { get; set; }
    }
}
