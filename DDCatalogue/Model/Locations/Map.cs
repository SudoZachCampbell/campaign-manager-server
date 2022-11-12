using DDCatalogue.Model.Joins;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDCatalogue.Model.Locations
{
    public class Map : Base, ILocation
    {
        public string Variation { get; set; }
        public string ImageUrl { get; set; }
        public JArray Center { get; set; }
        public Guid LocaleId { get; set; }
        public Locale Locale { get; set; }
        public List<BuildingMap> Buildings { get; set; }
    }
}
