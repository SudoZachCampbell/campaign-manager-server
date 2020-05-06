using System.Collections.Generic;

namespace DDCatalogue.Model.Locations
{
    public class Country
    {
        public int CountryId { get; set; }
        public string Name { get; set; }
        public List<Municipality> Municipalities { get; set; }
        public Continent Continent { get; set; }
        public byte[] Map { get; set; }
    }
}
