using CampaignManager.Data.Model.Creatures;
using CampaignManager.Data.Model.Games;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampaignManager.Data.Model.Joins
{
    [Table("campaigns_monsters")]
    public class CampaignMonster : IJoin
    {
        public Guid CampaignId { get; set; }
        public Campaign? Campaign { get; set; }
        public Guid MonsterId { get; set; }
        public Monster? Monster { get; set; }
    }
}
