using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DDCatalogue.Model.Locations
{
    [Table("regions")]
    public class Region : Owned, ILocation
    {
        public string Name { get; set; } = string.Empty;
        public List<Locale> Locales { get; set; }
        public Guid? ContinentId { get; set; }
        public Continent Continent { get; set; }
        public string Map { get; set; }
    }
}
