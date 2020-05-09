using System.Collections.Generic;

namespace DDCatalogue.Model.Locations
{
    public class Continent : ILocation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Region> Regions { get; set; }
        public byte[] Map { get; set; }
    }
}
