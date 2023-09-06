using System;
using System.ComponentModel.DataAnnotations.Schema;
using CampaignManager.Data.Model.Locations;
using Newtonsoft.Json.Linq;

namespace CampaignManager.Data.Model.Creatures
{
    [Table("npcs")]
    public class Npc : Owned, IOwned
    {
        public string Name { get; set; } = string.Empty;
        public string Background { get; set; } = string.Empty;
        public JArray? NoteableEvents { get; set; } = new JArray();
        public JArray? Beliefs { get; set; } = new JArray();
        public JArray? Passions { get; set; } = new JArray();
        public JArray? Flaws { get; set; } = new JArray();
        public string Picture { get; set; } = string.Empty;
        public Guid? MonsterId { get; set; }
        public Monster? Monster { get; set; }
        public Guid? LocaleId { get; set; }
        public Locale? Locale { get; set; }
        public Guid? BuildingId { get; set; }
        public Building? Building { get; set; }
    }
}
