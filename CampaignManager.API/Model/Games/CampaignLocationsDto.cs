using System.Collections.Generic;
using AutoMapper;
using CampaignManager.Data.Model.Games;
using CampaignManager.API.Model.Locations;

namespace CampaignManager.API.Model.Games
{
    [AutoMap(typeof(Campaign), ReverseMap = true)]
    public class CampaignWithLocationsDto
    {
        public List<WorldDto> Worlds { get; set; }
        public List<ContinentDto> Continents { get; set; }
        public List<RegionDto> Regions { get; set; }
        public List<LocaleDto> Locales { get; set; }
        public List<BuildingDto> Buildings { get; set; }
        public List<DungeonDto> Dungeons { get; set; }
    }
}