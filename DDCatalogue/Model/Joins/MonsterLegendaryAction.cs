using DDCatalogue.Model.Attributes;
using DDCatalogue.Model.Creatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDCatalogue.Model.Joins
{
    public class MonsterLegendaryAction
    {
        public int MonsterId { get; set; }
        public Monster Monster { get; set; }
        public int LegendaryActionId { get; set; }
        public LegendaryAction LegendaryAction { get; set; }
    }
}
