using DDCatalogue.Model.Creatures;
using DDCatalogue.Model.Joins;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace DDCatalogue.Model.Locations
{
    public class Building : Base, ILocation
    {
        public int? LocaleId { get; set; }
        public Locale Locale { get; set; }
        public string Map { get; set; }
        public List<Npc> Npcs { get; set; }
        public List<MonsterBuilding> Monsters { get; set; }
        public List<Player> Players { get; set; }
        public List<BuildingMap> Maps { get; set; }
    }
}
