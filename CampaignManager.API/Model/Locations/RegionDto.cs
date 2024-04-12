using System;
using System.Collections.Generic;
using CampaignManager.API.Model.Games;

namespace CampaignManager.API.Model.Locations
{
    public class RegionDto : BaseDto
    {
        public string Name { get; set; } = string.Empty;
        public List<LocaleDto>? Locales { get; set; }
        public Guid? ContinentId { get; set; }
        public ContinentDto? Continent { get; set; }
        public string Map { get; set; } = string.Empty;
        public Guid CampaignId { get; set; }
    }
}
