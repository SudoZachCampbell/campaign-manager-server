using System.ComponentModel.DataAnnotations.Schema;

namespace CampaignManager.Data.Model.Locations
{
    [Table("dungeons")]
    public class Dungeon : Base, ILocation
    {
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public byte[]? Map { get; set; }
        public Building? Building { get; set; }
        public Locale? Locale { get; set; }
    }
}
