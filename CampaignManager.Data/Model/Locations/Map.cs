using CampaignManager.Data.Model.Joins;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CampaignManager.Data.Model.Locations
{
    [Table("maps")]
    public class Map : Base, ILocation
    {
        public string Name { get; set; } = string.Empty;
        public string Variation { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public JArray? Center { get; set; }
        public Guid LocaleId { get; set; }
        public Locale? Locale { get; set; }
        public List<BuildingMap>? Buildings { get; set; }
    }
}
