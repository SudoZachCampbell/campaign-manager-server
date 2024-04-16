using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using CampaignManager.Data.Model.Games;

namespace CampaignManager.Data.Model.Locations
{
    [Table("regions")]
    public class Region : Base, ILocation, ICampaignBase
    {
        public string Description { get; set; } = string.Empty;
        public List<Locale>? Locales { get; set; }
        public Guid? ContinentId { get; set; }
        public Continent? Continent { get; set; }
        public List<Map>? Maps { get; set; }
        public Guid CampaignId { get; set; }
        public Campaign? Campaign { get; set; }
    }
}
