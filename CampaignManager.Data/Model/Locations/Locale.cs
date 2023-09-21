using System;
using CampaignManager.Data.Model.Creatures;
using CampaignManager.Data.Model.Joins;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using CampaignManager.Data.Model.Games;

namespace CampaignManager.Data.Model.Locations
{
    [Table("locales")]
    public class Locale : Base, ILocation, ICampaignBase
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
        public Guid CampaignId { get; set; }
        public Campaign? Campaign { get; set; }
    }
}
