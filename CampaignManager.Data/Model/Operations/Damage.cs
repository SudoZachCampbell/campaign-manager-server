
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CampaignManager.Data.Model.Operations
{
    public class Damage
    {
        [JsonPropertyName("damageType")]
        public string DamageType { get; set; } = string.Empty;
        [JsonPropertyName("damageDice")]
        public string DamageDice { get; set; } = string.Empty;
        [JsonPropertyName("damageBonus")]
        public int? DamageBonus { get; set; }
    }
}