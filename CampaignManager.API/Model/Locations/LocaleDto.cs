using System;
using System.Collections.Generic;
using CampaignManager.API.Model.Creatures;
using CampaignManager.API.Model.Joins;
using AutoMapper;
using CampaignManager.Data.Model.Locations;

namespace CampaignManager.API.Model.Locations
{
    [AutoMap(typeof(Locale), ReverseMap = true)]
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
    }
}
