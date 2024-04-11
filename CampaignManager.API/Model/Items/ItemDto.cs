using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CampaignManager.API.Model.Items
{
    public class ItemDto : BaseDto
    {
        public string Name { get; set; } = string.Empty;
    }
}
