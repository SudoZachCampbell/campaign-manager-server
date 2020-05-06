using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDCatalogue.Model
{
    public class Npc
    {
        public Npc(string name)
        {
            Name = name;
        }
        public int NpcId { get; set; }
        public string Name { get; set; }
        public Character Character { get; set; }
        public Monster Monster { get; set; }
    }
}
