using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DDCatalogue.Model.Operations
{
    public class CreatureAction
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("desc")]
        public string Desc { get; set; }
        [JsonPropertyName("count")]
        public int Count { get; set; }
        [JsonPropertyName("attackBonus")]
        public int AttackBonus { get; set; }
        [JsonPropertyName("damage")]
        public List<Damage> Damage { get; set; }
        [JsonPropertyName("usage")]
        public Usage Usage { get; set; }
        [JsonPropertyName("actions")]
        public List<CreatureAction> Actions { get; set; }
        [JsonPropertyName("dc")]
        public DC DC { get; set; }
    }

    public class Usage
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("times")]
        public string Times { get; set; }
        [JsonPropertyName("minValue")]
        public int MinValue { get; set; }
    }

    public class DC
    {
        [JsonPropertyName("dcType")]
        public string DcType { get; set; }
        [JsonPropertyName("dcValue")]
        public int DcValue { get; set; }
        [JsonPropertyName("successType")]
        public string SuccessType { get; set; }
    }
}
