using System.ComponentModel.DataAnnotations.Schema;

namespace CampaignManager.Data.Model.Locations
{
    [Table("dungeons")]
    public class Dungeon : Owned, ILocation
    {
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; }
        public byte[] Map { get; set; }
        public Building Building { get; set; }
        public Locale Locale { get; set; }
    }
}
