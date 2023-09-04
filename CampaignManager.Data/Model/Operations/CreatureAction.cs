using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CampaignManager.Data.Model.Operations
{
    public class CreatureAction
    {
        public string Name { get; set; } = string.Empty;
        [JsonPropertyName("multiattack_type")]
        public string MultiAttackType { get; set; } = string.Empty;
        public string Desc { get; set; } = string.Empty;
        public int? Count { get; set; }
        public int? AttackBonus { get; set; }
        public List<Damage>? Damage { get; set; }
        public Usage? Usage { get; set; }
        public List<SubAction>? Actions { get; set; }
        [JsonPropertyName("dc")]
        public DC? DC { get; set; }
    }

    public class Usage
    {
        public string Type { get; set; } = string.Empty;
        public int? Times { get; set; }
        public int? MinValue { get; set; }
        public string Dice { get; set; } = string.Empty;
    }

    public class DC
    {
        public string DcType { get; set; } = string.Empty;
        public int DcValue { get; set; }
        public string SuccessType { get; set; } = string.Empty;
    }

    public class SubAction
    {
        public string ActionName { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public int? Count { get; set; }
    }
}
