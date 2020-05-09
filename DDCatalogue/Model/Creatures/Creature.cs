using DDCatalogue.Model.Locations;
using System.ComponentModel.DataAnnotations;

namespace DDCatalogue.Model.Creatures
{
    public class Creature
    {
        public Creature(string name, int ac, int hp, Alignment alignment)
        {
            Name = name;
            Ac = ac;
            Hp = hp;
            Alignment = alignment;
        }
        public int CreatureId { get; set; }
        public string Name { get; set; }
        public int? Str { get; set; }
        public int? Dex { get; set; }
        public int? Con { get; set; }
        public int? Int { get; set; }
        public int? Wis { get; set; }
        public int? Cha { get; set; }
        public bool? Acrobatics { get; set; }
        public bool? AnimalHandling { get; set; }
        public bool? Arcana { get; set; }
        public bool? Athletics { get; set; }
        public bool? Deception { get; set; }
        public bool? History { get; set; }
        public bool? Insight { get; set; }
        public bool? Intimidation { get; set; }
        public bool? Investigations { get; set; }
        public bool? Medicine { get; set; }
        public bool? Nature { get; set; }
        public bool? Perception { get; set; }
        public bool? Performance { get; set; }
        public bool? Persuasion { get; set; }
        public bool? Religion { get; set; }
        public bool? SleightOfHand { get; set; }
        public bool? Stealth { get; set; }
        public bool? Survival { get; set; }
        public bool? SavStr { get; set; }
        public bool? SavDex { get; set; }
        public bool? SavCon { get; set; }
        public bool? SavInt { get; set; }
        public bool? SavWis { get; set; }
        public bool? SavCha { get; set; }
        public int Ac { get; set; }
        public int Hp { get; set; }
        public string HitDice { get; set; }
        public string Speed { get; set; }
        public string Languages { get; set; }
        public string[] Traits { get; set; }
        public Alignment Alignment { get; set; }
        public Locale Locale { get; set; }
        public Building Building { get; set; }
        public string[] Reactions { get; set; }
    }

    public enum Alignment
    {
        LG,
        LN,
        LE,
        NG,
        TN,
        NE,
        CG,
        CN,
        CE
    }
}
