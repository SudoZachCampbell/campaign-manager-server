using DDCatalogue.Model.Joins;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DDCatalogue.Model.Locations
{
    [Table("maps")]
    public class Map : Owned, ILocation
    {
        public string Name { get; set; } = string.Empty;
        public string Variation { get; set; }
        public string ImageUrl { get; set; }
        public JArray Center { get; set; }
        public Guid LocaleId { get; set; }
        public Locale Locale { get; set; }
        public List<BuildingMap> Buildings { get; set; }
    }
}
