using System;
using CampaignManager.Data.Model.Locations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using CampaignManager.Data.Model.Auth;

namespace CampaignManager.Data.Model.Creatures
{
    [Table("pcs")]
    public class Pc : Creature
    {
        public string PcName { get; set; } = string.Empty;
        public int Level = 1;
        public string Background { get; set; } = string.Empty;
        public string Faction { get; set; } = string.Empty;
        public string Race { get; set; } = string.Empty;
        public int Xp = 0;
        public bool Inspiration = false;
        public Guid? LocaleId { get; set; }
        public Locale? Locale { get; set; }
        public Guid? BuildingId { get; set; }
        public Building? Building { get; set; }
        public Guid? PlayerId { get; set; }
        public Account? Player { get; set; }
    }
}
