using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using CampaignManager.Data.Model.Games;

namespace CampaignManager.Data.Model.Locations
{
    [Table("worlds")]
    public class World : Base, ILocation, ICampaignBase
    {
        public string Description { get; set; } = string.Empty;
        public List<Continent>? Continents { get; set; }
        public List<Map>? Maps { get; set; }
        public Guid CampaignId { get; set; }
        public Campaign? Campaign { get; set; }
    }
}
