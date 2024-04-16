using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using CampaignManager.API.Model.Creatures;
using CampaignManager.API.Model.Games;
using CampaignManager.API.Model.Joins;
using AutoMapper;
using CampaignManager.Data.Model.Locations;

namespace CampaignManager.API.Model.Locations
{
    [AutoMap(typeof(Building), ReverseMap = true)]
    public class BuildingDto : BaseDto
    {
        public string Description { get; set; } = string.Empty;
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
