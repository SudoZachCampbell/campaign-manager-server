using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using CampaignManager.API.Model.Joins;
using CampaignManager.API.Model.Operations;
using AutoMapper;
using CampaignManager.Data.Model.Creatures;

namespace CampaignManager.API.Model.Creatures
{
    [AutoMap(typeof(Monster), ReverseMap = true)]
    public class MonsterDto : CreatureDto
    {
        public double ChallengeRating { get; set; } = 0;
        public int Xp { get; set; } = 0;
        public MonsterTypeDto Type { get; set; } = MonsterTypeDto.None;
        public List<CreatureActionDto>? Actions { get; set; }
        public List<CreatureActionDto>? LegendaryActions { get; set; }
        public List<CreatureActionDto>? SpecialAbilities { get; set; }
        public List<SenseDto>? Senses { get; set; }
        public List<NpcDto>? Npcs { get; set; }
        public List<MonsterLocaleDto>? Locales { get; set; }
        public List<MonsterBuildingDto>? Buildings { get; set; }
    }

    [AutoMap(typeof(Sense), ReverseMap = true)]
    public class SenseDto
    {
        public string Name { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
    }

    public enum MonsterTypeDto
    {
        Abberation,
        Beast,
        Celestial,
        Construct,
        Dragon,
        Elemental,
        Fey,
        Fiend,
        Giant,
        Humanoid,
        Monstrosity,
        Ooze,
        Plant,
        Undead,
        None
    }
}
