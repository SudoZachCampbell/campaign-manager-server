using System;
using DDCatalogue.Model.Creatures;
using DDCatalogue.Model.Joins;
using System.Collections.Generic;

namespace DDCatalogue.Model.Locations
{
    public class Locale : Base, ILocation
    {
        public Guid? RegionId { get; set; }
        public Region Region { get; set; }
        public List<Building> Buildings { get; set; }
        public List<Dungeon> Dungeons { get; set; }
        public List<Player> Players { get; set; }
        public List<Npc> Npcs { get; set; }
        public List<MonsterLocale> Monsters { get; set; }
        public List<Map> Maps { get; set; }
    }
}
