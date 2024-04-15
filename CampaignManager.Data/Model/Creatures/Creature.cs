using CampaignManager.Data.Model.Joins;
using CampaignManager.Data.Model.Attributes;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using CampaignManager.Data.Model.Operations;
using CampaignManager.Data.Model.Auth;

namespace CampaignManager.Data.Model.Creatures
{
    public class Creature : Base, ICreature
    {
        public string Name { get; set; } = string.Empty;
        public int Strength { get; set; } = 10;
        public int Dexterity { get; set; } = 10;
        public int Constitution { get; set; } = 10;
        public int Intelligence { get; set; } = 10;
        public int Wisdom { get; set; } = 10;
        public int Charisma { get; set; } = 10;
        [Column(TypeName = "jsonb")]
        public List<Proficiencies>? Proficiencies { get; set; }
        public int ArmorClass { get; set; } = 0;
        public int HitPoints { get; set; } = 0;
        public string HitDice { get; set; } = string.Empty;
        public Size Size { get; set; } = Size.Medium;
        [Column(TypeName = "jsonb")]
        public List<Speed>? Speed { get; set; }
        public string Languages { get; set; } = string.Empty;
        public Alignment Alignment { get; set; } = Alignment.Unaligned;
        [Column(TypeName = "jsonb")]
        public List<CreatureAction>? Reactions { get; set; }
        public string Picture { get; set; } = string.Empty;
    }

    public enum Alignment
    {
        LawfulGood,
        LawfulNeutral,
        LawfulEvil,
        NeutralGood,
        TrueNeutral,
        NeutralEvil,
        ChaoticGood,
        ChaoticNeutral,
        ChaoticEvil,
        Unaligned
    }

    public enum Size
    {
        Tiny,
        Medium,
        Large,
        Huge,
        Gargantuan
    }

}
