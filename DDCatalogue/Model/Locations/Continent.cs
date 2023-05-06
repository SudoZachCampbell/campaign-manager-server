using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DDCatalogue.Model.Locations
{
    [Table("continents")]
    public class Continent : Base, ILocation
    {
        public List<Region> Regions { get; set; }
        public byte[] Map { get; set; }
    }
}
