using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CampaignManager.API.Model.Operations
{
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

    public class UsageDto
    {
        public string Type { get; set; } = string.Empty;
        public int? Times { get; set; }
        public int? MinValue { get; set; }
        public string Dice { get; set; } = string.Empty;
    }

    public class DCDto
    {
        public string DcType { get; set; } = string.Empty;
        public int DcValue { get; set; }
        public string SuccessType { get; set; } = string.Empty;
    }

    public class SubActionDto
    {
        public string ActionName { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public int? Count { get; set; }
    }
}
