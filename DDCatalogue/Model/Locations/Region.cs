using System.Collections.Generic;

namespace DDCatalogue.Model.Locations
{
    public class Region : ILocation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Locale> Municipalities { get; set; }
        public Continent Continent { get; set; }
        public byte[] Map { get; set; }
    }
}
