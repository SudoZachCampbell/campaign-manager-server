using System.ComponentModel.DataAnnotations.Schema;
using CampaignManager.Data.Model.Games;

namespace CampaignManager.Data.Model.Locations
{
    [Table("dungeons")]
    public class Dungeon : Base, ILocation, ICampaignBase
    {
        public string Description { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public List<Map>? Maps { get; set; }
        public Building? Building { get; set; }
        public Locale? Locale { get; set; }
        public Guid CampaignId { get; set; }
        public Campaign? Campaign { get; set; }
    }
}
