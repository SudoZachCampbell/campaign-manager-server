using AutoMapper;
using CampaignManager.API.Model.Creatures;
using CampaignManager.Data.Model.Joins;
using System;

namespace CampaignManager.API.Model.Joins
{
    [AutoMap(typeof(NpcNpc), ReverseMap = true)]
    public class NpcNpcRelationshipDto
    {
        public Guid FromId { get; set; }
        public NpcDto? From { get; set; }
        public Guid ToId { get; set; }
        public NpcDto? To { get; set; }
    }
}
