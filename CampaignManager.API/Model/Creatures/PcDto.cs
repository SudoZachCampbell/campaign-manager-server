using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using CampaignManager.API.Model.Auth;
using CampaignManager.API.Model.Games;
using CampaignManager.API.Model.Locations;

namespace CampaignManager.API.Model.Creatures
{
    public class PcDto : CreatureDto
    {
        public string PcName { get; set; } = string.Empty;
        public int Level = 1;
        public string Background { get; set; } = string.Empty;
        public string Faction { get; set; } = string.Empty;
        public string Race { get; set; } = string.Empty;
        public int Xp = 0;
        public bool Inspiration = false;
        public Guid CampaignId { get; set; }
        public Guid? LocaleId { get; set; }
        public Guid? BuildingId { get; set; }
        public Guid? PlayerId { get; set; }
    }
}
