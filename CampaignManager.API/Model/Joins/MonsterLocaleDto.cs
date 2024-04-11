using System;
using System.ComponentModel.DataAnnotations.Schema;
using CampaignManager.API.Model.Creatures;
using CampaignManager.API.Model.Locations;

namespace CampaignManager.API.Model.Joins
{
    public class MonsterLocaleDto
    {
        public Guid MonsterId { get; set; }
        public MonsterDto? Monster { get; set; }
        public Guid LocaleId { get; set; }
        public LocaleDto? Locale { get; set; }
    }
}
