using DDCatalogue.Model.Locations;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDCatalogue.Model.Joins
{
    public class BuildingMap : IJoin
    {
        public int BuildingId { get; set; }
        public Building Building { get; set; }
        public int MapId { get; set; }
        public Map Map { get; set; }
        public JArray Coords { get; set; }
    }
}
