﻿using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using CampaignManager.API.Model.Operations;
using CampaignManager.API.Model.Attributes;
using AutoMapper;
using CampaignManager.Data.Model.Creatures;

namespace CampaignManager.API.Model.Creatures
{
    [AutoMap(typeof(Creature), ReverseMap = true)]
    public class CreatureDto : BaseDto
    {
        public int Strength { get; set; } = 10;
        public int Dexterity { get; set; } = 10;
        public int Constitution { get; set; } = 10;
        public int Intelligence { get; set; } = 10;
        public int Wisdom { get; set; } = 10;
        public int Charisma { get; set; } = 10;
        public List<ProficienciesDto>? Proficiencies { get; set; }
        public int ArmorClass { get; set; } = 0;
        public int HitPoints { get; set; } = 0;
        public string HitDice { get; set; } = string.Empty;
        public SizeDto Size { get; set; } = SizeDto.Medium;
        public List<SpeedDto>? Speed { get; set; }
        public string Languages { get; set; } = string.Empty;
        public AlignmentDto Alignment { get; set; } = AlignmentDto.Unaligned;
        public List<CreatureActionDto>? Reactions { get; set; }
        public string Picture { get; set; } = string.Empty;
    }

    public enum AlignmentDto
    {
        LawfulGood,
        LawfulNeutral,
        LawfulEvil,
        NeutralGood,
        TrueNeutral,
        NeutralEvil,
        ChaoticGood,
        ChaoticNeutral,
        ChaoticEvil,
        Unaligned,
    }

    public enum SizeDto
    {
        Tiny,
        Medium,
        Large,
        Huge,
        Gargantuan
    }

}
