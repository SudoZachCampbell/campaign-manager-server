
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CampaignManager.Data.Model.Operations
{
    public class Damage
    {
        public string DamageType { get; set; } = string.Empty;
        public string DamageDice { get; set; } = string.Empty;
        public int? DamageBonus { get; set; }
    }
}
