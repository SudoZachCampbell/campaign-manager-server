using System;
using CampaignManager.Data.Model.Creatures;
using CampaignManager.Data.Model.Joins;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampaignManager.Data.Model.Locations
{
    [Table("buildings")]
    public class Building : Base, ILocation
    {
        public string Name { get; set; } = string.Empty;
        public Guid? LocaleId { get; set; }
        public Locale? Locale { get; set; }
        public string Map { get; set; } = string.Empty;
        public List<Npc>? Npcs { get; set; }
        public List<MonsterBuilding>? Monsters { get; set; }
        public List<Pc>? Pcs { get; set; }
        public List<BuildingMap>? Maps { get; set; }
    }
}
