using CampaignManager.Data.Model.Creatures;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampaignManager.Data.Model.Joins
{
    [Table("npc_pc")]
    public class NpcPc : IJoin
    {
        public Guid NpcId { get; set; }
        public Npc? Npc { get; set; }
        public Guid PcId { get; set; }
        public Pc? Pc { get; set; }
    }
}
