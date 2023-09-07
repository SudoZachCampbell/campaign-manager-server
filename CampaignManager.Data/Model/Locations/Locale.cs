using System;
using CampaignManager.Data.Model.Creatures;
using CampaignManager.Data.Model.Joins;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampaignManager.Data.Model.Locations
{
    [Table("locales")]
    public class Locale : Owned, ILocation
    {
        public string Name { get; set; } = string.Empty;
        public Guid? RegionId { get; set; }
        public Region? Region { get; set; }
        public List<Building>? Buildings { get; set; }
        public List<Dungeon>? Dungeons { get; set; }
        public List<Pc>? Pcs { get; set; }
        public List<Npc>? Npcs { get; set; }
        public List<MonsterLocale>? Monsters { get; set; }
        public List<Map>? Maps { get; set; }
    }
}
