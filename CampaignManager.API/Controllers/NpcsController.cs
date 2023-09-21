using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CampaignManager.Data.Repositories;
using Microsoft.AspNetCore.JsonPatch;
using System;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using CampaignManager.API.ModelBinder;
using CampaignManager.Data.Model.Auth;
using CampaignManager.Data.Model.Creatures;

namespace CampaignManager.API.Controllers
{
    [Route("{campaignId}/[controller]"), Authorize]
    [ApiController]
    public class NpcsController : CampaignContextController<Npc>
    {
        public NpcsController(IConfiguration configuration) : base(configuration) { }

        // GET: api/Npcs
        [HttpGet]
        public ActionResult<IEnumerable<Npc>> GetNpcs(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] Account user,
            Guid campaignId, [FromQuery] ListingFilterParameters<Npc> query)
        {
            return GetGen(user.Id, campaignId, query);
        }

        // GET: api/Npc/5
        [HttpGet("{npcId}")]
        public ActionResult<Npc> GetNpcById(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] Account user,
            Guid campaignId, Guid npcId, [FromQuery] FilterParameters<Npc> query)
        {
            return GetGenById(user.Id, campaignId, npcId, query);
        }

        [HttpPatch("{npcId}")]
        public ActionResult<Npc> UpdateNpc(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] Account user,
            Guid campaignId, Guid npcId, [FromBody] JsonPatchDocument<Npc> patchDoc, [FromQuery] FilterParameters<Npc> query)
        {
            return PatchGen(user.Id, campaignId, npcId, patchDoc, query);
        }

        // PUT: api/Npc/5
        [HttpPut("{npcId}")]
        public IActionResult UpdateNpc(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] Account user,
            Guid campaignId, Guid npcId, Npc npc)
        {
            return PutGen(user.Id, campaignId, npcId, npc);
        }

        // POST: api/Npc
        [HttpPost]
        [ProducesResponseType(201)]
        public ActionResult<Guid> CreateNpc(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] Account user,
            Guid campaignId, Npc npc)
        {
            return PostGen(user.Id, campaignId, npc);
        }

        // DELETE: api/Npc/5
        [HttpDelete("{npcId}")]
        public ActionResult<Npc> DeleteNpc(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] Account user,
            Guid campaignId, Guid npcId)
        {
            return DeleteGen(user.Id, campaignId, npcId);
        }

        [HttpGet("[action]/{name}")]
        public ActionResult<List<string>> GetEnum(string name)
        {
            return GetEnumGen(name);
        }
    }
}
