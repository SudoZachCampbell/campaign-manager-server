using DDCatalogue.Model.Attributes;
using DDCatalogue.Model.Creatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDCatalogue.Model.Joins
{
    public class CreatureTrait
    {
        public int CreatureId { get; set; }
        public Creature Creature { get; set; }
        public int TraitId { get; set; }
        public Trait Trait { get; set; }
    }
}
