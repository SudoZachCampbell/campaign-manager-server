using DDCatalogue.Model.Joins;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DDCatalogue.Model.Creatures
{
    public class Creature : ICreature
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Strength { get; set; } = 0;
        public int Dexterity { get; set; } = 0;
        public int Constitution { get; set; } = 0;
        public int Intelligence { get; set; } = 0;
        public int Wisdom { get; set; } = 0;
        public int Charisma { get; set; } = 0;
        public JArray Proficiencies { get; set; } = new JArray();
        public int ArmorClass { get; set; } = 0;
        public int HitPoints { get; set; } = 0;
        public string HitDice { get; set; }
        public string Size { get; set; }
        public JArray Speed { get; set; }
        public string Languages { get; set; }
        public Alignment Alignment { get; set; }
        public JArray Reactions { get; set; }
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
