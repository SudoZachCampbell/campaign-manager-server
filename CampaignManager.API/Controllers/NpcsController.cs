using System;
using CampaignManager.Data.Model.Creatures;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using CampaignManager.Data.Repositories;

namespace CampaignManager.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NpcsController : GenericController<Npc>
    {
        public NpcsController(IConfiguration configuration) : base(configuration) { }

        [HttpGet]
        public ActionResult<List<Npc>> Get([FromQuery] ListingFilterParameters<Npc> parameters)
        {
            return GetGen(parameters);
        }


        [HttpGet("{id}")]
        public ActionResult<Npc> Get(Guid id, [FromQuery] FilterParameters<Npc> query)
        {
            return GetGen(id, query);
        }

        [HttpPatch("{id}")]
        public ActionResult<Npc> Patch(Guid id, [FromBody] JsonPatchDocument<Npc> patchDoc, [FromQuery] FilterParameters<Npc> query)
        {
            return PatchGen(id, patchDoc, query);
        }

        // [HttpGet("[action]")]
        // public ActionResult<dynamic> Table()
        // {
        //     dynamic npcs = UnitOfWork.Repository.Get()
        //         .Select(n => new
        //         {
        //             id = n.Id,
        //             name = n.Name,
        //             monsterName = n.Monster.Name,
        //             location = n.Building.Name != null ? $"{n.Building.Name} in {n.Locale.Name}" : n.Locale.Name
        //         }).ToList();
        //     return npcs;
        // }
    }
}
