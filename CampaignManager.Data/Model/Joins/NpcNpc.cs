using CampaignManager.Data.Model.Creatures;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampaignManager.Data.Model.Joins
{
    [Table("npc_npc")]
    public class NpcNpc : IJoin
    {
        public Guid FromId { get; set; }
        public Npc? From { get; set; }
        public Guid ToId { get; set; }
        public Npc? To { get; set; }
    }
}
