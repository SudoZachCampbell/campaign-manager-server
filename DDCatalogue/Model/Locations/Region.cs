using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DDCatalogue.Model.Locations
{
    [Table("regions")]
    public class Region : Base, ILocation
    {
        public List<Locale> Locales { get; set; }
        public Guid? ContinentId { get; set; }
        public Continent Continent { get; set; }
        public string Map { get; set; }
    }
}
