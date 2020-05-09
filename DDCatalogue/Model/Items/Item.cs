using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDCatalogue.Model.Items
{
    public class Item : IItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
