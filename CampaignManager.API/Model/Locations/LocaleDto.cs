using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using CampaignManager.API.Model.Creatures;
using CampaignManager.API.Model.Games;
using CampaignManager.API.Model.Joins;

namespace CampaignManager.API.Model.Locations
{
    public class LocaleDto : BaseDto
    {
        public string Name { get; set; } = string.Empty;
        public Guid? RegionId { get; set; }
        public RegionDto? Region { get; set; }
        public List<BuildingDto>? Buildings { get; set; }
        public List<DungeonDto>? Dungeons { get; set; }
        public List<PcDto>? Pcs { get; set; }
        public List<NpcDto>? Npcs { get; set; }
        public List<MonsterLocaleDto>? Monsters { get; set; }
        public List<MapDto>? Maps { get; set; }
        public Guid CampaignId { get; set; }
        public CampaignDto? Campaign { get; set; }
    }
}
