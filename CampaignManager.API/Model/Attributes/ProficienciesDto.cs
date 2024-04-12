using System.Text.Json.Serialization;

namespace CampaignManager.API.Model.Attributes
{
    public class ProficienciesDto
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
        [JsonPropertyName("value")]
        public int Value { get; set; }
    }
}