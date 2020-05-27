using DDCatalogue.Model.Locations;

namespace DDCatalogue.Model.Creatures
{
    public class Creature : ICreature
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Strength { get; set; }
        public int? Dexterity { get; set; }
        public int? Constitution { get; set; }
        public int? Intelligence { get; set; }
        public int? Wisdom { get; set; }
        public int? Charisma { get; set; }
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
        public int ArmorClass { get; set; }
        public int HitPoints { get; set; }
        public string HitDice { get; set; }
        public string Speed { get; set; }
        public string Languages { get; set; }
        public string[] Traits { get; set; }
        public Alignment Alignment { get; set; }
        public string[] Reactions { get; set; }
        public string Picture { get; set; }
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
        CE,
        Any,
        None
    }

}
