using System;
using System.ComponentModel.DataAnnotations.Schema;
using CampaignManager.API.Model.Games;

namespace CampaignManager.API.Model.Locations
{
    public class DungeonDto : BaseDto
    {
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public byte[]? Map { get; set; }
        public BuildingDto? Building { get; set; }
        public LocaleDto? Locale { get; set; }
        public Guid CampaignId { get; set; }
        public CampaignDto? Campaign { get; set; }
    }
}
