using DDCatalogue.Model.Creatures;
using System.Collections.Generic;

namespace DDCatalogue.Model.Locations
{
    public class Municipality
    {
        public int MunicipalityId { get; set; }
        public string Name { get; set; }
        public Country Country { get; set; }
        public List<Building> Buildings { get; set; }
        public byte[] Map { get; set; }
        public List<Character> Characters { get; set; }
    }
}
