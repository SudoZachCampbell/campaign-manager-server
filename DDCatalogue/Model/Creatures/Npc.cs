using DDCatalogue.Model.Locations;
using Newtonsoft.Json.Linq;

namespace DDCatalogue.Model.Creatures
{
    public class Npc : ICreature
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public string Background { get; set; }
        public JArray NoteableEvents { get; set; }
        public JArray Beliefs { get; set; }
        public JArray Passions { get; set; }
        public JArray Flaws { get; set; }
        public int? MonsterId { get; set; }
        public Monster Monster { get; set; }
        public int? LocaleId { get; set; }
        public Locale Locale { get; set; }
        public int? BuildingId { get; set; }
        public Building Building { get; set; }
    }
}
