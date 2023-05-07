using System;
using System.ComponentModel.DataAnnotations.Schema;
using CampaignManager.Data.Model.Creatures;
using CampaignManager.Data.Model.Locations;

namespace CampaignManager.Data.Model.Joins
{
    [Table("monsters_buildings")]
    public class MonsterBuilding : IJoin
    {
        public Guid MonsterId { get; set; }
        public Monster? Monster { get; set; }
        public Guid BuildingId { get; set; }
        public Building? Building { get; set; }
    }
}
