using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CampaignManager.API.Model.Auth;
using CampaignManager.Data.Model;
using AutoMapper;

namespace CampaignManager.API.Model
{
    [AutoMap(typeof(Base), ReverseMap = true)]
    public class BaseDto
    {
        public Guid? Id { get; set; } = Guid.NewGuid();
        public Guid? OwnerId { get; set; }
    }
}
