using System;
using System.Collections.Generic;
using AutoMapper;
using CampaignManager.Data.Model.Locations;

namespace CampaignManager.API.Model.Locations
{
    [AutoMap(typeof(Region), ReverseMap = true)]
    public class RegionDto : BaseDto
    {
        public string Description { get; set; } = string.Empty;
        public List<LocaleDto>? Locales { get; set; }
        public Guid? ContinentId { get; set; }
        public ContinentDto? Continent { get; set; }
        public string Map { get; set; } = string.Empty;
        public Guid CampaignId { get; set; }
    }
}
