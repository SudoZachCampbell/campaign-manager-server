using CampaignManager.API.Model.Locations;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CampaignManager.API.Model.Joins
{
    public class BuildingMapDto
    {
        public Guid BuildingId { get; set; }
        public BuildingDto? Building { get; set; }
        public Guid MapId { get; set; }
        public MapDto Map { get; set; }
        public List<int> Coords { get; set; }
    }
}
