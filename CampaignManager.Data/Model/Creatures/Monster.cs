using System.ComponentModel.DataAnnotations.Schema;
using CampaignManager.Data.Model.Operations;
using CampaignManager.Data.Model.Joins;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using CampaignManager.Data.Model.Auth;

namespace CampaignManager.Data.Model.Creatures
{
    [Table("monsters")]
    public class Monster : Creature
    {
        public double ChallengeRating { get; set; } = 0;
        public int Xp { get; set; } = 0;
        public int PassivePerception { get; set; } = 0;
        public MonsterType MonsterType { get; set; } = MonsterType.None;
        [Column(TypeName = "jsonb")]
        public List<CreatureAction>? Actions { get; set; }
        [Column(TypeName = "jsonb")]
        public List<CreatureAction>? LegendaryActions { get; set; }
        [Column(TypeName = "jsonb")]
        public List<CreatureAction>? SpecialAbilities { get; set; }
        [Column(TypeName = "jsonb")]
        public List<Sense>? Senses { get; set; }
        public List<Npc>? Npcs { get; set; }
        public List<MonsterLocale>? Locales { get; set; }
        public List<MonsterBuilding>? Buildings { get; set; }
    }

    public class Sense
    {
        public string Name { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
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
