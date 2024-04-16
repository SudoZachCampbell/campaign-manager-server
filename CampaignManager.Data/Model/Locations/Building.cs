using System;
using CampaignManager.Data.Model.Creatures;
using CampaignManager.Data.Model.Joins;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using CampaignManager.Data.Model.Games;

namespace CampaignManager.Data.Model.Locations
{
    [Table("buildings")]
    public class Building : Base, ILocation, ICampaignBase
    {
        public string Description { get; set; } = string.Empty;
        public Guid? LocaleId { get; set; }
        public Locale? Locale { get; set; }
        public List<Npc>? Npcs { get; set; }
        public List<MonsterBuilding>? Monsters { get; set; }
        public List<Pc>? Pcs { get; set; }
        public List<BuildingMap>? Maps { get; set; }
        public Guid CampaignId { get; set; }
        public Campaign? Campaign { get; set; }
    }
}
