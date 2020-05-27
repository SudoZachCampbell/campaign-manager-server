using DDCatalogue.Model.Joins;
using System.Collections.Generic;

namespace DDCatalogue.Model.Creatures
{
    public class Monster : Creature
    {
        public double ChallengeRating { get; set; }
        public int DefeatXp { get; set; }
        public int PassivePerception { get; set; }
        public List<Action> Actions { get; set; }
        public List<LegendaryAction> LegendaryActions { get; set; }
        public List<Sense> Senses { get; set; }
        public List<Npc> Npcs { get; set; }
        public List<MonsterLocale> Locales { get; set; }
        public List<MonsterBuilding> Buildings { get; set; }
    }

    public class Action
    {
        public string Name { get; set; }
        public string Desc { get; set; }
    }

    public class LegendaryAction
    {
        public string Name { get; set; }
        public string Desc { get; set; }
    }

    public class Sense
    {
        public string Name { get; set; }
        public string Desc { get; set; }
    }
}
