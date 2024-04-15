using System.Text.Json.Serialization;
using AutoMapper;
using CampaignManager.Data.Model.Attributes;

namespace CampaignManager.API.Model.Attributes
{
    [AutoMap(typeof(Proficiencies), ReverseMap = true)]
    public class ProficienciesDto
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
        [JsonPropertyName("value")]
        public int Value { get; set; }
    }
}