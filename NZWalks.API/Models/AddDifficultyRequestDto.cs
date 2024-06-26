using Newtonsoft.Json;

namespace NZWalks.API.Models
{
    public class AddDifficultyRequestDto
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
