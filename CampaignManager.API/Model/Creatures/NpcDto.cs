using System;
using System.ComponentModel.DataAnnotations.Schema;
using CampaignManager.API.Model.Games;
using CampaignManager.API.Model.Locations;
using Newtonsoft.Json.Linq;

namespace CampaignManager.API.Model.Creatures
{
    public class NpcDto : BaseDto
    {
        public string Name { get; set; } = string.Empty;
        public string Background { get; set; } = string.Empty;
        public string? NoteableEvents { get; set; } = string.Empty;
        public string? Beliefs { get; set; } = string.Empty;
        public string? Passions { get; set; } = string.Empty;
        public string? Flaws { get; set; } = string.Empty;
        public string Picture { get; set; } = string.Empty;
        public Guid? MonsterId { get; set; }
        public MonsterDto? Monster { get; set; }
        public Guid? LocaleId { get; set; }
        public LocaleDto? Locale { get; set; }
        public Guid? BuildingId { get; set; }
        public BuildingDto? Building { get; set; }
        public Guid CampaignId { get; set; }
        public CampaignDto? Campaign { get; set; }
    }
}
