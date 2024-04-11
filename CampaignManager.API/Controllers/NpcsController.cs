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
using CampaignManager.API.Model.Auth;
using AutoMapper;
using CampaignManager.API.Model.Creatures;

namespace CampaignManager.API.Controllers
{
    [Route("{campaignId}/[controller]"), Authorize]
    [ApiController]
    public class NpcsController : CampaignContextController<Npc>
    {
        public NpcsController(IConfiguration configuration, IMapper mapper) : base(configuration, mapper) { }

        // GET: api/Npcs
        [HttpGet]
        public IEnumerable<NpcDto> GetNpcs(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] AccountDto user,
            Guid campaignId, [FromQuery] ListingFilterParameters<Npc> query)
        {
            return Mapper.Map<IEnumerable<NpcDto>>(GetGen(user.Id, campaignId, query));
        }

        // GET: api/Npc/5
        [HttpGet("{npcId}")]
        public NpcDto GetNpcById(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] AccountDto user,
            Guid campaignId, Guid npcId, [FromQuery] FilterParameters<Npc> query)
        {
            return Mapper.Map<NpcDto>(GetGenById(user.Id, campaignId, npcId, query));
        }

        [HttpPatch("{npcId}")]
        public NpcDto UpdateNpc(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] AccountDto user,
            Guid campaignId, Guid npcId, [FromBody] JsonPatchDocument<Npc> patchDoc, [FromQuery] FilterParameters<Npc> query)
        {
            return Mapper.Map<NpcDto>(PatchGen(user.Id, campaignId, npcId, patchDoc, query));
        }

        // PUT: api/Npc/5
        [HttpPut("{npcId}")]
        public IActionResult UpdateNpc(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] AccountDto user,
            Guid campaignId, Guid npcId, NpcDto npc)
        {
            return PutGen(user.Id, campaignId, npcId, Mapper.Map<Npc>(npc));
        }

        // POST: api/Npc
        [HttpPost]
        [ProducesResponseType(201)]
        public ActionResult<Guid> CreateNpc(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] AccountDto user,
            Guid campaignId, NpcDto npc)
        {
            return PostGen(user.Id, campaignId, Mapper.Map<Npc>(npc));
        }

        // DELETE: api/Npc/5
        [HttpDelete("{npcId}")]
        public NpcDto DeleteNpc(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] AccountDto user,
            Guid campaignId, Guid npcId)
        {
            return Mapper.Map<NpcDto>(DeleteGen(user.Id, campaignId, npcId));
        }

        [HttpGet("[action]/{name}")]
        public ActionResult<List<string>> GetEnum(string name)
        {
            return GetEnumGen(name);
        }
    }
}
