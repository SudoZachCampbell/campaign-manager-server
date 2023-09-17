using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CampaignManager.Data.Model.Auth;

namespace CampaignManager.Data.Model
{
    public class Base : IBase
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid OwnerId { get; set; }
        public Account? Owner { get; set; }
    }
}
