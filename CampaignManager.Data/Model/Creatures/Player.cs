using System;
using CampaignManager.Data.Model.Locations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampaignManager.Data.Model.Creatures
{
    [Table("players")]
    public class Player : Creature
    {
        public string CharacterName { get; set; } = string.Empty;
        public string PlayerName { get; set; }
        public int Level = 1;
        public string Background { get; set; }
        public string Faction { get; set; }
        public string Race { get; set; }
        public int Xp = 0;
        public bool Inspiration = false;
        public Guid? LocaleId { get; set; }
        public Locale Locale { get; set; }
        public Guid? BuildingId { get; set; }
        public Building Building { get; set; }

    }
}
