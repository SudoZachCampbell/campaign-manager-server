using DDCatalogue.Model.Creatures;
using System.Collections.Generic;

namespace DDCatalogue.Model.Locations
{
    public class Building
    {
        public int BuildingId { get; set; }
        public string Name { get; set; }
        public Municipality Municipality { get; set; }
        public List<Character> Characters { get; set; }
        public byte[] Map { get; set; }
    }
}
