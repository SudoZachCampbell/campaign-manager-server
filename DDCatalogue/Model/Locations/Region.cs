using System.Collections.Generic;

namespace DDCatalogue.Model.Locations
{
    public class Region
    {
        public int RegionId { get; set; }
        public string Name { get; set; }
        public List<Locale> Municipalities { get; set; }
        public Continent Continent { get; set; }
        public byte[] Map { get; set; }
    }
}
