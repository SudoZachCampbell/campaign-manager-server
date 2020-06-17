using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDCatalogue.Model.Locations
{
    public class Map : ILocation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public JArray Center { get; set; }
        public Locale Location { get; set; }

    }
}
