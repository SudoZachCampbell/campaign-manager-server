using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CampaignManager.Data.Repositories;
using Microsoft.AspNetCore.JsonPatch;
using System;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using CampaignManager.API.ModelBinder;
using CampaignManager.Data.Model.Auth;
using CampaignManager.Data.Model.Locations;
using CampaignManager.API.Model.Auth;
using AutoMapper;
using CampaignManager.API.Model.Locations;

namespace CampaignManager.API.Controllers
{
    [Route("{campaignId}/[controller]"), Authorize]
    [ApiController]
    public class BuildingsController : CampaignContextController<Building>
    {
        public BuildingsController(IConfiguration configuration, IMapper mapper) : base(configuration, mapper) { }

        // GET: api/Buildings
        [HttpGet]
        public IEnumerable<BuildingDto> GetBuildings(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] AccountDto user,
            Guid campaignId, [FromQuery] ListingFilterParameters<Building> query)
        {
            return Mapper.Map<IEnumerable<BuildingDto>>(GetGen(user.Id, campaignId, query));
        }

        // GET: api/Building/5
        [HttpGet("{buildingId}")]
        public BuildingDto GetBuildingById(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] AccountDto user,
            Guid campaignId, Guid buildingId, [FromQuery] FilterParameters<Building> query)
        {
            return Mapper.Map<BuildingDto>(GetGenById(user.Id, campaignId, buildingId, query));
        }

        [HttpPatch("{buildingId}")]
        public BuildingDto UpdateBuilding(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] AccountDto user,
            Guid campaignId, Guid buildingId, [FromBody] JsonPatchDocument<Building> patchDoc, [FromQuery] FilterParameters<Building> query)
        {
            return Mapper.Map<BuildingDto>(PatchGen(user.Id, campaignId, buildingId, patchDoc, query));
        }

        // PUT: api/Building/5
        [HttpPut("{buildingId}")]
        public IActionResult UpdateBuilding(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] AccountDto user,
            Guid campaignId, Guid buildingId, BuildingDto building)
        {
            return PutGen(user.Id, campaignId, buildingId, Mapper.Map<Building>(building));
        }

        // POST: api/Building
        [HttpPost]
        [ProducesResponseType(201)]
        public ActionResult<Guid> CreateBuilding(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] AccountDto user,
            Guid campaignId, BuildingDto building)
        {
            return PostGen(user.Id, campaignId, Mapper.Map<Building>(building));
        }

        // DELETE: api/Building/5
        [HttpDelete("{buildingId}")]
        public BuildingDto DeleteBuilding(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] AccountDto user,
            Guid campaignId, Guid buildingId)
        {
            return Mapper.Map<BuildingDto>(DeleteGen(user.Id, campaignId, buildingId));
        }

        [HttpGet("[action]/{name}")]
        public ActionResult<List<string>> GetEnum(string name)
        {
            return GetEnumGen(name);
        }
    }
}
