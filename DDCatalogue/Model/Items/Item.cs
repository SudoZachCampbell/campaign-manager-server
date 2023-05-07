using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DDCatalogue.Model.Items
{
    [Table("items")]
    public class Item : Owned, IItem
    {
        public string Name { get; set; } = string.Empty;
    }
}
