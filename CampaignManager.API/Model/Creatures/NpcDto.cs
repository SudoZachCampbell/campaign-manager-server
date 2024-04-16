using System;
using System.ComponentModel.DataAnnotations.Schema;
using CampaignManager.API.Model.Games;
using CampaignManager.API.Model.Locations;
using Newtonsoft.Json.Linq;
using AutoMapper;
using CampaignManager.Data.Model.Creatures;

namespace CampaignManager.API.Model.Creatures
{
    [AutoMap(typeof(Npc), ReverseMap = true)]
    public class NpcDto : BaseDto
    {
        public string Background { get; set; } = string.Empty;
        public string? NoteableEvents { get; set; } = string.Empty;
        public string? Beliefs { get; set; } = string.Empty;
        public string? Passions { get; set; } = string.Empty;
        public string? Flaws { get; set; } = string.Empty;
        public string Picture { get; set; } = string.Empty;
        public Guid? MonsterId { get; set; }
        public Guid? LocaleId { get; set; }
        public Guid? BuildingId { get; set; }
        public Guid CampaignId { get; set; }
    }
}
