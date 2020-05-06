using System.Collections.Generic;

namespace DDCatalogue.Model.Locations
{
    public class Continent
    {
        public int ContinentId { get; set; }
        public string Name { get; set; }
        public List<Country> Countries { get; set; }
        public byte[] Map { get; set; }
    }
}
