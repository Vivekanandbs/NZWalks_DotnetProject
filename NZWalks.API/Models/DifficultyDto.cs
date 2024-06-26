using Newtonsoft.Json;

namespace NZWalks.API.Models
{
    public class DifficultyDto
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
