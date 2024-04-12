using System;
using System.ComponentModel.DataAnnotations.Schema;
using CampaignManager.API.Model.Creatures;
using CampaignManager.API.Model.Games;

namespace CampaignManager.API.Model.Joins
{
    public class CampaignMonsterDto
    {
        public Guid CampaignId { get; set; }
        public CampaignDto? Campaign { get; set; }
        public Guid MonsterId { get; set; }
        public MonsterDto? Monster { get; set; }
    }
}
