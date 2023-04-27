using System.Text.Json.Serialization;

namespace DDCatalogue.Model.Attributes
{
    public class Speed
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("value")]
        public int Value { get; set; }
        [JsonPropertyName("measurement")]
        public string Measurement { get; set; }
    }
}