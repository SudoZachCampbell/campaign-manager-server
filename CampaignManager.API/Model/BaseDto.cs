using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CampaignManager.API.Model.Auth;

namespace CampaignManager.API.Model
{
    public class BaseDto
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid OwnerId { get; set; }
        public AccountDto? Owner { get; set; }
    }
}
