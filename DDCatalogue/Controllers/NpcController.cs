using Amazon.Runtime;
using DDCatalogue.Model;
using DDCatalogue.Model.Creatures;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace DDCatalogue.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NpcController : ControllerBase
    {

        private UnitOfWork<Npc> UnitOfWork = new UnitOfWork<Npc>();

        [HttpGet]
        public ActionResult<List<Npc>> Get([FromQuery] string include)
        {
            return UnitOfWork.Repository.Get(includeProperties: include?.Split(',')).ToList();
        }

         
        [HttpGet("{id}")]
        public ActionResult<Npc> Get(int id, [FromQuery] string include)
        {
            Npc npc = UnitOfWork.Repository.GetById(id, includeProperties: include?.Split(','));

            if (npc == null) return NotFound();

            return npc;
        }

        [HttpPatch("{id}")]
        public ActionResult<Npc> Patch(int id, [FromBody] JsonPatchDocument<Npc> patchDoc)
        {
            if (patchDoc != null)
            {
                Npc npc = UnitOfWork.Repository.GetById(id);

                if (npc != null)
                {
                    patchDoc.ApplyTo(npc, ModelState);
                }
                else
                {
                    return BadRequest(ModelState);
                }

                UnitOfWork.Repository.Update(npc);
                UnitOfWork.Save();

                return npc;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet("[action]")]
        public ActionResult<dynamic> Table()
        {
            dynamic npcs = UnitOfWork.Repository.Get()
                .Select(n => new
                {
                    id = n.Id,
                    name = n.Name,
                    monsterName = n.Monster.Name,
                    location = n.Building.Name != null ? $"{n.Building.Name} in {n.Locale.Name}" : n.Locale.Name
                }).ToList();
            return npcs;
        }
    }
}
