using DDCatalogue.Model.Creatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDCatalogue.Model.Joins
{
    public class MonsterAction
    {
        public int MonsterId { get; set; }
        public Monster Monster { get; set; }
        public int ActionId { get; set; }
        public Action Action { get; set; }
    }
}
