using DDCatalogue.Model.Joins;
using System.Collections.Generic;

namespace DDCatalogue.Model.Creatures
{
    public class Monster : Creature
    {
        public string Senses { get; set; }
        public double Challenge { get; set; }
        public int DefeatXp { get; set; }
        public int PassivePerception { get; set; }
        public string[] Actions { get; set; }
        public string[] LegendaryActions { get; set; }
        public List<Npc> Npcs { get; set; }
        public List<MonsterLocale> Locales { get; set; }
        public List<MonsterBuilding> Buildings { get; set; }
    }
}
