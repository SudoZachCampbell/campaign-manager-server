
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CampaignManager.API.Model.Operations
{
    public class DamageDto
    {
        public string DamageType { get; set; } = string.Empty;
        public string DamageDice { get; set; } = string.Empty;
        public int? DamageBonus { get; set; }
    }
}
