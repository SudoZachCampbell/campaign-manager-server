using DDCatalogue.Model.Locations;
using System.Collections.Generic;

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
        public List<Proficiency> Proficiencies { get; set; }
        public int ArmorClass { get; set; }
        public int HitPoints { get; set; }
        public string HitDice { get; set; }
        public string Speed { get; set; }
        public string Languages { get; set; }
        public List<Trait> Traits { get; set; }
        public Alignment Alignment { get; set; }
        public List<Reaction> Reactions { get; set; }
        public string Picture { get; set; }
    }

    public class Proficiency
    {
        public string Name { get; set; }
        public int Value { get; set; }
    }

    public class Reaction { 
        public string Name { get; set; }
        public string Desc { get; set; }
    }

    public class Trait
    {
        public string Name { get; set; }
        public string Desc { get; set; }
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
