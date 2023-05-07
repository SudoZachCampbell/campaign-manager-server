using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampaignManager.Data.Model.Locations
{
    [Table("continents")]
    public class Continent : Owned, ILocation
    {
        public string Name { get; set; } = string.Empty;
        public List<Region> Regions { get; set; }
        public byte[] Map { get; set; }
    }
}
