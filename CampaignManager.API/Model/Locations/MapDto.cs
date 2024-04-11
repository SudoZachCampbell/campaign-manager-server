using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using CampaignManager.API.Model.Games;
using CampaignManager.API.Model.Joins;

namespace CampaignManager.API.Model.Locations
{
    public class MapDto : BaseDto
    {
        public string Name { get; set; } = string.Empty;
        public string Variation { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public JArray? Center { get; set; }
        public Guid LocaleId { get; set; }
        public LocaleDto? Locale { get; set; }
        public List<BuildingMapDto>? Buildings { get; set; }
        public Guid CampaignId { get; set; }
        public CampaignDto? Campaign { get; set; }
    }
}
