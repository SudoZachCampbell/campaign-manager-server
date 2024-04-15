
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using AutoMapper;
using CampaignManager.Data.Model.Operations;

namespace CampaignManager.API.Model.Operations
{
    [AutoMap(typeof(Damage), ReverseMap = true)]
    public class DamageDto
    {
        public string DamageType { get; set; } = string.Empty;
        public string DamageDice { get; set; } = string.Empty;
        public int? DamageBonus { get; set; }
    }
}
