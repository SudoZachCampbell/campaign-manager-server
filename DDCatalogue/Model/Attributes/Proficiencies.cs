using System.Text.Json.Serialization;

namespace DDCatalogue.Model.Attributes
{
    public class Proficiencies
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("value")]
        public int Value { get; set; }
    }
}