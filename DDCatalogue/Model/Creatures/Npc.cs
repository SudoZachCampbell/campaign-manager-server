using DDCatalogue.Model.Locations;

namespace DDCatalogue.Model.Creatures
{
    public class Npc : ICreature
    {
        public Npc(string name)
        {
            Name = name;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public int? MonsterId { get; set; }
        public Monster Monster { get; set; }
        public int? LocaleId { get; set; }
        public Locale Locale { get; set; }
        public int? BuildingId { get; set; }
        public Building Building { get; set; }
    }
}
