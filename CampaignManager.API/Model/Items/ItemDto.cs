using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CampaignManager.Data.Model.Items;

namespace CampaignManager.API.Model.Items
{
    [AutoMap(typeof(Item), ReverseMap = true)]
    public class ItemDto : BaseDto
    {
        public string Name { get; set; } = string.Empty;
    }
}
