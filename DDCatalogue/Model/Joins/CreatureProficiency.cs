using DDCatalogue.Model.Attributes;
using DDCatalogue.Model.Creatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDCatalogue.Model.Joins
{
    public class CreatureProficiency
    {
        public int CreatureId { get; set; }
        public Creature Creature { get; set; }
        public int ProficiencyId { get; set; }
        public Proficiency Proficiency { get; set; }
    }
}
