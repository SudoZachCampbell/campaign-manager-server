using DDCatalogue.Model.Joins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDCatalogue.Model.Attributes
{
    public class Proficiency : IAttribute
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
        public List<CreatureProficiency> Creatures { get; set; }
    }
}
