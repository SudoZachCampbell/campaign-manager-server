using System;
using CampaignManager.Data.Model.Creatures;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using CampaignManager.Data.Repositories;
using Microsoft.AspNetCore.Authorization;
using CampaignManager.API.ModelBinder;
using CampaignManager.Data.Model.Auth;

namespace CampaignManager.API.Controllers
{
    [Route("[controller]"), Authorize]
    [ApiController]
    public class NpcsController : GenericController<Npc>
    {
        public NpcsController(IConfiguration configuration) : base(configuration) { }

        // GET: api/Npcs
        [HttpGet]
        public ActionResult<List<Npc>> GetNpcs([FromQuery] ListingFilterParameters<Npc> query)
        {
            return GetGen(query);
        }

        // GET: api/Npc/5
        [HttpGet("{id}")]
        public ActionResult<Npc> GetNpcById(Guid id, [FromQuery] FilterParameters<Npc> query)
        {
            return GetGen(id, query);
        }

        [HttpPatch("{id}")]
        public ActionResult<Npc> UpdateNpc(Guid id, [FromBody] JsonPatchDocument<Npc> patchDoc, [FromQuery] FilterParameters<Npc> query)
        {
            return PatchGen(id, patchDoc, query);
        }

        // PUT: api/Npc/5
        [HttpPut("{id}")]
        public IActionResult UpdateNpc(Guid id, Npc npc)
        {
            return PutGen(id, npc);
        }

        // POST: api/Npc
        [HttpPost]
        [ProducesResponseType(201)]
        public ActionResult<Guid> CreateNpc(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] Account user,
            Npc npc)
        {
            npc.OwnerId = user.Id;
            return PostGen(npc);
        }

        // DELETE: api/Npc/5
        [HttpDelete("{id}")]
        public ActionResult<Npc> DeleteNpc(Guid id)
        {
            return DeleteGen(id);
        }

        [HttpGet("[action]/{name}")]
        public ActionResult<List<string>> GetEnum(string name)
        {
            return GetEnumGen(name);
        }
    }
}
