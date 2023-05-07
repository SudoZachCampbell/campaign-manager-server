using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CampaignManager.Data.Model.Attributes
{
    public class Speed
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
        [JsonPropertyName("value")]
        public int Value { get; set; }
        [JsonPropertyName("measurement")]
        public string Measurement { get; set; } = string.Empty;
    }
}