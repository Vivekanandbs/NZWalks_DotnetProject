using Newtonsoft.Json;

namespace NZWalks.API.Models
{
    public class RoleDto
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("role_name")]
        public string RoleName { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("is_active")]
        public bool IsActive { get; set; }
    }
}
