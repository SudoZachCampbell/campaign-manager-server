using AutoMapper;
using CampaignManager.API.Model.Creatures;
using CampaignManager.API.Model.Games;
using CampaignManager.API.Model.Locations;
using CampaignManager.Data.Model.Creatures;
using CampaignManager.Data.Model.Games;
using CampaignManager.Data.Model.Locations;

public class ModelMappingProfile : Profile
{
    public ModelMappingProfile()
    {
        CreateMap<Building, BuildingDto>();
        CreateMap<Campaign, CampaignDto>();
        CreateMap<Continent, ContinentDto>();
        CreateMap<Locale, LocaleDto>();
        CreateMap<Monster, MonsterDto>();
        CreateMap<Npc, NpcDto>();
        CreateMap<Pc, PcDto>();
        CreateMap<Region, RegionDto>();
        CreateMap<World, WorldDto>();
        // Use CreateMap... Etc.. here (Profile methods are the same as configuration methods)
    }
}