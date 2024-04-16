using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CampaignManager.Data.Repositories;
using Microsoft.AspNetCore.JsonPatch;
using System;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using CampaignManager.API.ModelBinder;
using CampaignManager.Data.Model.Locations;
using CampaignManager.API.Model.Auth;
using AutoMapper;
using CampaignManager.API.Model.Locations;
using Microsoft.Extensions.Logging.Abstractions;

namespace CampaignManager.API.Controllers
{
    [Route("{campaignId}/[controller]"), Authorize]
    [ApiController]
    public class WorldsController : CampaignContextController<World>
    {
        public WorldsController(IConfiguration configuration, IMapper mapper) : base(configuration, mapper) { }

        // GET: api/Worlds
        [HttpGet]
        public IEnumerable<WorldDto> GetWorlds(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] AccountDto user,
            Guid campaignId, [FromQuery] ListingFilterParameters<World> query)
        {
            return Mapper.Map<IEnumerable<WorldDto>>(GetGen(user.Id, campaignId, query));
        }

        // GET: api/Worlds/5
        [HttpGet("{worldId}")]
        public WorldDto GetWorldById(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] AccountDto user,
            Guid campaignId, Guid worldId, [FromQuery] FilterParameters<World> query)
        {
            return Mapper.Map<WorldDto>(GetGenById(user.Id, campaignId, worldId, query));
        }

        [HttpGet("worlds")]
        public IEnumerable<WorldDto> GetCampaignWorlds(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] AccountDto user,
            Guid campaignId)
        {
            return Mapper.Map<IEnumerable<WorldDto>>(GetByCampaign(user.Id, campaignId));
        }

        [HttpPatch("{worldId}")]
        public WorldDto UpdateWorld(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] AccountDto user,
            Guid campaignId, Guid worldId)
        {
            return Mapper.Map<WorldDto>(PatchGen(user.Id, campaignId, worldId, null));
        }

        // PUT: api/World/5
        [HttpPut("{worldId}")]
        public IActionResult UpdateWorld(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] AccountDto user,
            Guid campaignId, Guid worldId, WorldDto world)
        {
            return PutGen(user.Id, campaignId, worldId, Mapper.Map<World>(world));
        }

        // POST: api/World
        [HttpPost]
        [ProducesResponseType(201)]
        public ActionResult<Guid> CreateWorld(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] AccountDto user,
            Guid campaignId, WorldDto world)
        {
            return PostGen(user.Id, campaignId, Mapper.Map<World>(world));
        }

        // DELETE: api/World/5
        [HttpDelete("{worldId}")]
        public WorldDto DeleteWorld(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] AccountDto user,
            Guid campaignId, Guid worldId)
        {
            return Mapper.Map<WorldDto>(DeleteGen(user.Id, campaignId, worldId));
        }

        [HttpGet("[action]/{name}")]
        public ActionResult<List<string>> GetEnum(string name)
        {
            return GetEnumGen(name);
        }
    }
}
