using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using CampaignManager.Data.Model.Games;

namespace CampaignManager.Data.Model.Locations
{
    [Table("regions")]
    public class Region : Base, ILocation, ICampaignBase
    {
        public string Name { get; set; } = string.Empty;
        public List<Locale>? Locales { get; set; }
        public Guid? ContinentId { get; set; }
        public Continent? Continent { get; set; }
        public string Map { get; set; } = string.Empty;
        public Guid CampaignId { get; set; }
        public Campaign? Campaign { get; set; }
    }
}
