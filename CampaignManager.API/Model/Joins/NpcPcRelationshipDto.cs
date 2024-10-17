using AutoMapper;
using CampaignManager.API.Model.Creatures;
using CampaignManager.Data.Model.Joins;
using System;

namespace CampaignManager.API.Model.Joins
{
    [AutoMap(typeof(NpcPc), ReverseMap = true)]
    public class NpcPcRelationshipDto
    {
        public Guid NpcId { get; set; }
        public NpcDto? Npc { get; set; }
        public Guid PcId { get; set; }
        public PcDto? Pc { get; set; }
    }
}
