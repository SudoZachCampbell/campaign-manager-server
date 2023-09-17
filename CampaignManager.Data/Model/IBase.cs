using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CampaignManager.Data.Model.Auth;

namespace CampaignManager.Data.Model
{
    public interface IBase
    {
        Guid Id { get; set; }
        Guid OwnerId { get; set; }
        Account? Owner { get; set; }
    }
}
