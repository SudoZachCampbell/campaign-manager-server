using DDCatalogue.Model.Joins;
using System.Collections.Generic;

namespace DDCatalogue.Model.Creatures
{
    public class Creature : ICreature
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Subtype { get; set; }
        public int? Strength { get; set; }
        public int? Dexterity { get; set; }
        public int? Constitution { get; set; }
        public int? Intelligence { get; set; }
        public int? Wisdom { get; set; }
        public int? Charisma { get; set; }
        /// <summary>
        /// Convert from JSON
        /// </summary>
        public string Proficiencies { get; set; }
        public int ArmorClass { get; set; }
        public int HitPoints { get; set; }
        public string HitDice { get; set; }
        public string Size { get; set; }
        /// <summary>
        /// Convert from JSON
        /// </summary>
        public string Speed { get; set; }
        public string Languages { get; set; }
        public Alignment Alignment { get; set; }
        /// <summary>
        /// Convert from JSON
        /// </summary>
        public string Reactions { get; set; }
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
