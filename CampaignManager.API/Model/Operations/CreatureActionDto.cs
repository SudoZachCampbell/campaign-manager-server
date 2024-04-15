using System.Collections.Generic;
using System.Text.Json.Serialization;
using AutoMapper;
using CampaignManager.Data.Model.Operations;

namespace CampaignManager.API.Model.Operations
{
    [AutoMap(typeof(CreatureAction), ReverseMap = true)]
    public class CreatureActionDto
    {
        public string Name { get; set; } = string.Empty;
        [JsonPropertyName("multiattack_type")]
        public string MultiAttackType { get; set; } = string.Empty;
        public string Desc { get; set; } = string.Empty;
        public int? Count { get; set; }
        public int? AttackBonus { get; set; }
        public List<DamageDto>? Damage { get; set; }
        public UsageDto? Usage { get; set; }
        public List<SubActionDto>? Actions { get; set; }
        [JsonPropertyName("dc")]
        public DCDto? DC { get; set; }
    }

    [AutoMap(typeof(Usage), ReverseMap = true)]
    public class UsageDto
    {
        public string Type { get; set; } = string.Empty;
        public int? Times { get; set; }
        public int? MinValue { get; set; }
        public string Dice { get; set; } = string.Empty;
    }

    [AutoMap(typeof(DC), ReverseMap = true)]
    public class DCDto
    {
        public string DcType { get; set; } = string.Empty;
        public int DcValue { get; set; }
        public string SuccessType { get; set; } = string.Empty;
    }

    [AutoMap(typeof(SubAction), ReverseMap = true)]
    public class SubActionDto
    {
        public string ActionName { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public int? Count { get; set; }
    }
}
