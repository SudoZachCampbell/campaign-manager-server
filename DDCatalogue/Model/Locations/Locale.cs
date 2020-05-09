using DDCatalogue.Model.Creatures;
using System.Collections.Generic;

namespace DDCatalogue.Model.Locations
{
    public class Locale
    {
        public int LocaleId { get; set; }
        public string Name { get; set; }
        public Region Region { get; set; }
        public List<Building> Buildings { get; set; }
        public byte[] Map { get; set; }
        public List<Character> Characters { get; set; }
    }
}
