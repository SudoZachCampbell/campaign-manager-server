using DDCatalogue.Model.Joins;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace DDCatalogue.Model.Creatures
{
    public class Monster : Creature
    {
        public double ChallengeRating { get; set; } = 0;
        public int PassivePerception { get; set; } = 0;
        public MonsterType Type { get; set; } = MonsterType.None;
        public JArray Actions { get; set; } = new JArray();
        public JArray LegendaryActions { get; set; } = new JArray();
        public JArray SpecialAbilities { get; set; } = new JArray();
        public JObject Senses { get; set; } = new JObject();
        public List<Npc> Npcs { get; set; }
        public List<MonsterLocale> Locales { get; set; }
        public List<MonsterBuilding> Buildings { get; set; }
    }

    public enum MonsterType
    {
        Abberation,
        Beast,
        Celestial,
        Construct,
        Dragon,
        Elemental,
        Fey,
        Fiend,
        Giant,
        Humanoid,
        Monstrosity,
        Ooze,
        Plant,
        Undead,
        None
    }
}
