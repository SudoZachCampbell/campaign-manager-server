using System;
using System.ComponentModel.DataAnnotations.Schema;
using CampaignManager.Data.Model.Games;
using CampaignManager.Data.Model.Joins;
using CampaignManager.Data.Model.Locations;
using Newtonsoft.Json.Linq;

namespace CampaignManager.Data.Model.Creatures
{
    [Table("npcs")]
    public class Npc : Base, IBase, ICampaignBase
    {
        public string Epithet { get; set; } = string.Empty;
        public string Picture { get; set; } = string.Empty;
        [Column(TypeName = "jsonb")]
        public NpcLore? Lore { get; set; }
        [Column(TypeName = "jsonb")]
        public NpcAttributes? Attributes { get; set; }
        public List<NpcNpc>? NpcRelationShipsFrom { get; set; }
        public List<NpcNpc>? NpcRelationShipTo { get; set; }
        public List<NpcPc>? PcRelationships { get; set; }
        public Guid? MonsterId { get; set; }
        public Monster? Monster { get; set; }
        public Guid? LocaleId { get; set; }
        public Locale? Locale { get; set; }
        public Guid? BuildingId { get; set; }
        public Building? Building { get; set; }
        public Guid CampaignId { get; set; }
        public Campaign? Campaign { get; set; }
    }

    public class NpcLore
    {
        public string Secrets { get; set; } = string.Empty;
        public string UsefulKnowledge { get; set; } = string.Empty;
        public string Beliefs { get; set; } = string.Empty;
        public string Background { get; set; } = string.Empty;
        public string Affiliations { get; set; } = string.Empty;
        public string Occupation { get; set; } = string.Empty;
    }

    public class NpcAttributes
    {
        public string Race { get; set; } = string.Empty;
        public string Age { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public string Appearance { get; set; } = string.Empty;
        public bool AliveStatus { get; set; } = true;
        public string Flaws { get; set; } = string.Empty;
        public string Passions { get; set; } = string.Empty;
    }
}
