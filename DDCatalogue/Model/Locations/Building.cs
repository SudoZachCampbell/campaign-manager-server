using DDCatalogue.Model.Creatures;
using System.Collections.Generic;

namespace DDCatalogue.Model.Locations
{
    public class Building : ILocation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Locale Locale { get; set; }
        public List<Player> Characters { get; set; }
        public byte[] Map { get; set; }
    }
}
