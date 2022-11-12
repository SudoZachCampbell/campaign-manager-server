using System;
using System.Collections.Generic;

namespace DDCatalogue.Model.Locations
{
    public class Region : Base, ILocation
    {
        public List<Locale> Locales { get; set; }
        public Guid? ContinentId { get; set; }
        public Continent Continent { get; set; }
        public string Map { get; set; }
    }
}
