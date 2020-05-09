using DDCatalogue.Model.Creatures;
using System.Collections.Generic;

namespace DDCatalogue.Model.Locations
{
    public class Locale : ILocation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Region Region { get; set; }
        public List<Building> Buildings { get; set; }
        public List<Dungeon> Dungeons { get; set; }
        public byte[] Map { get; set; }
        public List<Player> Characters { get; set; }
    }
}
