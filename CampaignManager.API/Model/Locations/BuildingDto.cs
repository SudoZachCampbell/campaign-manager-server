using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using CampaignManager.API.Model.Creatures;
using CampaignManager.API.Model.Games;
using CampaignManager.API.Model.Joins;

namespace CampaignManager.API.Model.Locations
{
    public class BuildingDto : BaseDto
    {
        public string Name { get; set; } = string.Empty;
        public Guid? LocaleId { get; set; }
        public LocaleDto? Locale { get; set; }
        public string Map { get; set; } = string.Empty;
        public List<NpcDto>? Npcs { get; set; }
        public List<MonsterBuildingDto>? Monsters { get; set; }
        public List<PcDto>? Pcs { get; set; }
        public List<BuildingMapDto>? Maps { get; set; }
        public Guid CampaignId { get; set; }
    }
}
