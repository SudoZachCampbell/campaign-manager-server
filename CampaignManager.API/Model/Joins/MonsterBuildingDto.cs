using System;
using System.ComponentModel.DataAnnotations.Schema;
using CampaignManager.API.Model.Creatures;
using CampaignManager.API.Model.Locations;

namespace CampaignManager.API.Model.Joins
{
    public class MonsterBuildingDto
    {
        public Guid MonsterId { get; set; }
        public MonsterDto? Monster { get; set; }
        public Guid BuildingId { get; set; }
        public BuildingDto? Building { get; set; }
    }
}
