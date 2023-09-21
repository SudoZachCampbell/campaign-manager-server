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

namespace CampaignManager.API.Controllers
{
    [Route("{campaignId}/[controller]"), Authorize]
    [ApiController]
    public class BuildingsController : CampaignContextController<Building>
    {
        public BuildingsController(IConfiguration configuration) : base(configuration) { }

        // GET: api/Buildings
        [HttpGet]
        public ActionResult<IEnumerable<Building>> GetBuildings(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] Account user,
            Guid campaignId, [FromQuery] ListingFilterParameters<Building> query)
        {
            return GetGen(user.Id, campaignId, query);
        }

        // GET: api/Building/5
        [HttpGet("{buildingId}")]
        public ActionResult<Building> GetBuildingById(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] Account user,
            Guid campaignId, Guid buildingId, [FromQuery] FilterParameters<Building> query)
        {
            return GetGenById(user.Id, campaignId, buildingId, query);
        }

        [HttpPatch("{buildingId}")]
        public ActionResult<Building> UpdateBuilding(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] Account user,
            Guid campaignId, Guid buildingId, [FromBody] JsonPatchDocument<Building> patchDoc, [FromQuery] FilterParameters<Building> query)
        {
            return PatchGen(user.Id, campaignId, buildingId, patchDoc, query);
        }

        // PUT: api/Building/5
        [HttpPut("{buildingId}")]
        public IActionResult UpdateBuilding(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] Account user,
            Guid campaignId, Guid buildingId, Building building)
        {
            return PutGen(user.Id, campaignId, buildingId, building);
        }

        // POST: api/Building
        [HttpPost]
        [ProducesResponseType(201)]
        public ActionResult<Guid> CreateBuilding(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] Account user,
            Guid campaignId, Building building)
        {
            return PostGen(user.Id, campaignId, building);
        }

        // DELETE: api/Building/5
        [HttpDelete("{buildingId}")]
        public ActionResult<Building> DeleteBuilding(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] Account user,
            Guid campaignId, Guid buildingId)
        {
            return DeleteGen(user.Id, campaignId, buildingId);
        }

        [HttpGet("[action]/{name}")]
        public ActionResult<List<string>> GetEnum(string name)
        {
            return GetEnumGen(name);
        }
    }
}
