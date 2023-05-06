using System;
using DDCatalogue.Model;
using DDCatalogue.Model.Creatures;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace DDCatalogue.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NpcsController : GenericController<Npc>
    {
        public NpcsController(IConfiguration configuration) : base(configuration) { }

        [HttpGet]
        public ActionResult<List<Npc>> Get([FromQuery] ListingParameters<Npc> parameters)
        {
            return GetGen(parameters);
        }


        [HttpGet("{id}")]
        public ActionResult<Npc> Get(Guid id, [FromQuery] string include)
        {
            return GetGen(id, include);
        }

        [HttpPatch("{id}")]
        public ActionResult<Npc> Patch(Guid id, [FromBody] JsonPatchDocument<Npc> patchDoc, [FromQuery] string include)
        {
            return PatchGen(id, patchDoc, include);
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
