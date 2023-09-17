using System;
using System.ComponentModel.DataAnnotations.Schema;
using CampaignManager.Data.Model.Locations;
using Newtonsoft.Json.Linq;

namespace CampaignManager.Data.Model.Creatures
{
    [Table("npcs")]
    public class Npc : Base, IBase
    {
        public string Name { get; set; } = string.Empty;
        public string Background { get; set; } = string.Empty;
        public string? NoteableEvents { get; set; } = string.Empty;
        public string? Beliefs { get; set; } = string.Empty;
        public string? Passions { get; set; } = string.Empty;
        public string? Flaws { get; set; } = string.Empty;
        public string Picture { get; set; } = string.Empty;
        public Guid? MonsterId { get; set; }
        public Monster? Monster { get; set; }
        public Guid? LocaleId { get; set; }
        public Locale? Locale { get; set; }
        public Guid? BuildingId { get; set; }
        public Building? Building { get; set; }
    }
}
