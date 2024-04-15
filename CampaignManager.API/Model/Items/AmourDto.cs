using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CampaignManager.Data.Model.Items;

namespace CampaignManager.API.Model.Items
{
    [AutoMap(typeof(Armour), ReverseMap = true)]
    public class ArmourDto : ItemDto
    {

    }
}
