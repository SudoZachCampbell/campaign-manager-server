using System;
using DDCatalogue.Model.Locations;
using Newtonsoft.Json.Linq;

namespace DDCatalogue.Model.Creatures
{
    public class Npc : Base, ICreature
    {
        public string Picture { get; set; } = string.Empty;
        public string Background { get; set; } = string.Empty;
        public JArray NoteableEvents { get; set; } = new JArray();
        public JArray Beliefs { get; set; } = new JArray();
        public JArray Passions { get; set; } = new JArray();
        public JArray Flaws { get; set; } = new JArray();
        public Guid? MonsterId { get; set; }
        public Monster Monster { get; set; }
        public Guid? LocaleId { get; set; }
        public Locale Locale { get; set; }
        public Guid? BuildingId { get; set; }
        public Building Building { get; set; }
    }
}
