using System;
using System.ComponentModel.DataAnnotations.Schema;
using CampaignManager.API.Model.Games;
using AutoMapper;
using CampaignManager.Data.Model.Locations;

namespace CampaignManager.API.Model.Locations
{
    [AutoMap(typeof(Dungeon), ReverseMap = true)]
    public class DungeonDto : BaseDto
    {
        public string Description { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public byte[]? Map { get; set; }
        public BuildingDto? Building { get; set; }
        public LocaleDto? Locale { get; set; }
        public Guid CampaignId { get; set; }
    }
}
