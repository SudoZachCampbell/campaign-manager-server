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
    public class WorldsController : CampaignContextController<World>
    {
        public WorldsController(IConfiguration configuration) : base(configuration) { }

        // GET: api/Worlds
        [HttpGet]
        public ActionResult<IEnumerable<World>> GetWorlds(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] Account user,
            Guid campaignId, [FromQuery] ListingFilterParameters<World> query)
        {
            return GetGen(user.Id, campaignId, query);
        }

        // GET: api/World/5
        [HttpGet("world")]
        public ActionResult<World> GetCampaignWorld(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] Account user,
            Guid campaignId, [FromQuery] FilterParameters<World> query)
        {
            return GetSingleByCampaign(user.Id, campaignId);
        }

        [HttpPatch("{worldId}")]
        public ActionResult<World> UpdateWorld(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] Account user,
            Guid campaignId, Guid worldId, [FromBody] JsonPatchDocument<World> patchDoc, [FromQuery] FilterParameters<World> query)
        {
            return PatchGen(user.Id, campaignId, worldId, patchDoc, query);
        }

        // PUT: api/World/5
        [HttpPut("{worldId}")]
        public IActionResult UpdateWorld(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] Account user,
            Guid campaignId, Guid worldId, World world)
        {
            return PutGen(user.Id, campaignId, worldId, world);
        }

        // POST: api/World
        [HttpPost]
        [ProducesResponseType(201)]
        public ActionResult<Guid> CreateWorld(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] Account user,
            Guid campaignId, World world)
        {
            return PostGen(user.Id, campaignId, world);
        }

        // DELETE: api/World/5
        [HttpDelete("{worldId}")]
        public ActionResult<World> DeleteWorld(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] Account user,
            Guid campaignId, Guid worldId)
        {
            return DeleteGen(user.Id, campaignId, worldId);
        }

        [HttpGet("[action]/{name}")]
        public ActionResult<List<string>> GetEnum(string name)
        {
            return GetEnumGen(name);
        }
    }
}
