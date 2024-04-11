using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using CampaignManager.API.Model.Games;

namespace CampaignManager.API.Model.Locations
{
    public class ContinentDto : BaseDto
    {
        public string Name { get; set; } = string.Empty;
        public Guid? WorldId { get; set; }
        public WorldDto? World { get; set; }
        public List<RegionDto>? Regions { get; set; }
        public byte[]? Map { get; set; }
        public Guid CampaignId { get; set; }
        public CampaignDto? Campaign { get; set; }
    }
}
