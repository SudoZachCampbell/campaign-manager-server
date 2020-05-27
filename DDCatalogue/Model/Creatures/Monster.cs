using DDCatalogue.Model.Joins;
using System.Collections.Generic;

namespace DDCatalogue.Model.Creatures
{
    public class Monster : Creature
    {
        public double ChallengeRating { get; set; }
        public int DefeatXp { get; set; }
        public int PassivePerception { get; set; }
        public List<MonsterAction> Actions { get; set; }
        public List<MonsterLegendaryAction> LegendaryActions { get; set; }
        /// <summary>
        /// Convert from JSON
        /// </summary>
        public string Senses { get; set; }
        public List<Npc> Npcs { get; set; }
        public List<MonsterLocale> Locales { get; set; }
        public List<MonsterBuilding> Buildings { get; set; }
    }
}
