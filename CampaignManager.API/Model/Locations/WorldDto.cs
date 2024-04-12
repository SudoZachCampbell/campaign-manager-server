using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using CampaignManager.API.Model.Games;

namespace CampaignManager.API.Model.Locations
{
    public class WorldDto : BaseDto
    {
        public string Name { get; set; } = string.Empty;
        public List<ContinentDto>? Continents { get; set; }
        public byte[]? Map { get; set; }
        public Guid CampaignId { get; set; }
    }
}
