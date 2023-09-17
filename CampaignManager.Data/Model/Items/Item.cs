using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CampaignManager.Data.Model.Items
{
    [Table("items")]
    public class Item : Base, IItem
    {
        public string Name { get; set; } = string.Empty;
    }
}
