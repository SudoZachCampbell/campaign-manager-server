using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDCatalogue.Model.Attributes
{
    public interface IAttribute
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
