using System.ComponentModel.DataAnnotations.Schema;
using DDCatalogue.Model.Operations;
using DDCatalogue.Model.Joins;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace DDCatalogue.Model.Creatures
{
    public class Monster : Creature
    {
        public double ChallengeRating { get; set; } = 0;
        public int Xp { get; set; } = 0;
        public int PassivePerception { get; set; } = 0;
        public MonsterType MonsterType { get; set; } = MonsterType.None;
        [Column(TypeName = "jsonb")]
        public List<CreatureAction> Actions { get; set; }
        [Column(TypeName = "jsonb")]
        public List<CreatureAction> LegendaryActions { get; set; }
        [Column(TypeName = "jsonb")]
        public List<CreatureAction> SpecialAbilities { get; set; }
        [Column(TypeName = "jsonb")]
        public Dictionary<string, string> Senses { get; set; }
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
