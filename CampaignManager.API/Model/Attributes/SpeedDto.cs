using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using AutoMapper;
using CampaignManager.Data.Model.Attributes;

namespace CampaignManager.API.Model.Attributes
{
    [AutoMap(typeof(Speed), ReverseMap = true)]
    public class SpeedDto
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
        [JsonPropertyName("value")]
        public int Value { get; set; }
        [JsonPropertyName("measurement")]
        public string Measurement { get; set; } = string.Empty;
    }
}