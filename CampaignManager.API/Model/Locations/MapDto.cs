using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using CampaignManager.API.Model.Joins;
using AutoMapper;
using CampaignManager.Data.Model.Locations;

namespace CampaignManager.API.Model.Locations
{
    [AutoMap(typeof(Map), ReverseMap = true)]
    public class MapDto : BaseDto
    {
        public string Name { get; set; } = string.Empty;
        public string Variation { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public JArray? Center { get; set; }
        public Guid LocaleId { get; set; }
        public List<BuildingMapDto>? Buildings { get; set; }
        public Guid CampaignId { get; set; }
    }
}
