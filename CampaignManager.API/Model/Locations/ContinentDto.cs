using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using CampaignManager.API.Model.Games;
using AutoMapper;
using CampaignManager.Data.Model.Locations;

namespace CampaignManager.API.Model.Locations
{
    [AutoMap(typeof(Continent), ReverseMap = true)]
    public class ContinentDto : BaseDto
    {
        public string Name { get; set; } = string.Empty;
        public Guid? WorldId { get; set; }
        public WorldDto? World { get; set; }
        public List<RegionDto>? Regions { get; set; }
        public byte[]? Map { get; set; }
        public Guid CampaignId { get; set; }
    }
}
