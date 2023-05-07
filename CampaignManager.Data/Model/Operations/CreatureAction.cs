using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CampaignManager.Data.Model.Operations
{
    public class CreatureAction
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
        [JsonPropertyName("type")]
        public string Type { get; set; } = string.Empty;
        [JsonPropertyName("desc")]
        public string Desc { get; set; } = string.Empty;
        [JsonPropertyName("count")]
        public int? Count { get; set; }
        [JsonPropertyName("attackBonus")]
        public int? AttackBonus { get; set; }
        [JsonPropertyName("damage")]
        public List<Damage>? Damage { get; set; }
        [JsonPropertyName("usage")]
        public Usage? Usage { get; set; }
        [JsonPropertyName("actions")]
        public List<CreatureAction>? Actions { get; set; }
        [JsonPropertyName("dc")]
        public DC? DC { get; set; }
    }

    public class Usage
    {
        [JsonPropertyName("type")]
        public string Type { get; set; } = string.Empty;
        [JsonPropertyName("times")]
        public int? Times { get; set; }
        [JsonPropertyName("minValue")]
        public int? MinValue { get; set; }
    }

    public class DC
    {
        [JsonPropertyName("dcType")]
        public string DcType { get; set; } = string.Empty;
        [JsonPropertyName("dcValue")]
        public int DcValue { get; set; }
        [JsonPropertyName("successType")]
        public string SuccessType { get; set; } = string.Empty;
    }
}
