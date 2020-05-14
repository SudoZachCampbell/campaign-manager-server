using DDCatalogue.Model.Creatures;
using DDCatalogue.Model.Joins;
using System.Collections.Generic;

namespace DDCatalogue.Model.Locations
{
    public class Building : ILocation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? LocaleId { get; set; }
        public byte[] Map { get; set; }
        public List<Npc> Npcs { get; set; }
        public List<MonsterBuilding> Monsters { get; set; }
        public List<Player> Players { get; set; }
    }
}
