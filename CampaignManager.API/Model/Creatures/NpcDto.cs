using System;
using System.ComponentModel.DataAnnotations.Schema;
using CampaignManager.API.Model.Games;
using CampaignManager.API.Model.Locations;
using Newtonsoft.Json.Linq;
using AutoMapper;
using CampaignManager.Data.Model.Creatures;
using CampaignManager.API.Model.Joins;
using System.Collections.Generic;

namespace CampaignManager.API.Model.Creatures
{

    [AutoMap(typeof(Npc), ReverseMap = true)]
    public class NpcDto : BaseDto
    {
        public string Epithet { get; set; } = string.Empty;
        public string Picture { get; set; } = string.Empty;
        public NpcLoreDto? Lore { get; set; }
        public NpcAttributesDto? Attributes { get; set; }
        public List<NpcNpcRelationshipDto>? NpcRelationships { get; set; }
        public List<NpcPcRelationshipDto>? PcRelationships { get; set; }
        public Guid? MonsterId { get; set; }
        public Guid? LocaleId { get; set; }
        public Guid? BuildingId { get; set; }
        public Guid CampaignId { get; set; }
    }

    [AutoMap(typeof(NpcLore), ReverseMap = true)]
    public class NpcLoreDto
    {
        public string Secrets { get; set; } = string.Empty;
        public string UsefulKnowledge { get; set; } = string.Empty;
        public string Beliefs { get; set; } = string.Empty;
        public string Background { get; set; } = string.Empty;
        public string Affiliations { get; set; } = string.Empty;
        public string Occupation { get; set; } = string.Empty;
    }

    [AutoMap(typeof(NpcAttributes), ReverseMap = true)]
    public class NpcAttributesDto
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
