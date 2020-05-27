using DDCatalogue.Model.Joins;
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
        public List<CreatureProficiency> Proficiencies { get; set; }
        public int ArmorClass { get; set; }
        public int HitPoints { get; set; }
        public string HitDice { get; set; }
        public string Size { get; set; }
        /// <summary>
        /// Convert from JSON
        /// </summary>
        public string Speed { get; set; }
        public string Languages { get; set; }
        public List<CreatureTrait> Traits { get; set; }
        public Alignment Alignment { get; set; }
        public List<CreatureReaction> Reactions { get; set; }
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
