using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using CampaignManager.Data.Model.Games;

namespace CampaignManager.Data.Model.Locations
{
    [Table("continents")]
    public class Continent : Base, ILocation, ICampaignBase
    {
        public string Description { get; set; } = string.Empty;
        public Guid? WorldId { get; set; }
        public World? World { get; set; }
        public List<Region>? Regions { get; set; }
        public List<Map>? Maps { get; set; }
        public Guid CampaignId { get; set; }
        public Campaign? Campaign { get; set; }
    }
}
