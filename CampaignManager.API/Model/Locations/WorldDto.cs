using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using CampaignManager.API.Model.Games;
using AutoMapper;
using CampaignManager.Data.Model.Locations;

namespace CampaignManager.API.Model.Locations
{
    [AutoMap(typeof(World), ReverseMap = true)]
    public class WorldDto : BaseDto
    {
        public string Name { get; set; } = string.Empty;
        public List<ContinentDto>? Continents { get; set; }
        public byte[]? Map { get; set; }
        public Guid CampaignId { get; set; }
    }
}
