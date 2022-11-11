using System.Collections.Generic;

namespace DDCatalogue.Model.Locations
{
    public class Continent : Base, ILocation
    {
        public List<Region> Regions { get; set; }
        public byte[] Map { get; set; }
    }
}
