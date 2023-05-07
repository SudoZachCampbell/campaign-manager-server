using CampaignManager.Data.Model.Creatures;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using CampaignManager.Data.Repositories;

namespace CampaignManager.API.Controllers
{
    [Route("[controller]"), Authorize]
    [ApiController]
    public class MonstersController : GenericController<Monster>
    {
        public MonstersController(IConfiguration configuration) : base(configuration) { }

        // GET: api/Monster
        [HttpGet]
        public ActionResult<List<Monster>> GetMonsters([FromQuery] FilterParameters<Monster> query)
        {
            return GetGen(query);
        }

        // GET: api/Monster/5
        [HttpGet("{id}")]
        public ActionResult<Monster> GetMonsterById(Guid id, [FromQuery] string include)
        {
            return GetGen(id, include);
        }

        [HttpPatch("{id}")]
        public ActionResult<Monster> UpdateMonster(Guid id, [FromBody] JsonPatchDocument<Monster> patchDoc, [FromQuery] string include)
        {
            return PatchGen(id, patchDoc, include);
        }

        // PUT: api/Monster/5
        [HttpPut("{id}")]
        public IActionResult UpdateMonster(Guid id, Monster monster)
        {
            return PutGen(id, monster);
        }

        // POST: api/Monster
        [HttpPost]
        public ActionResult<Monster> CreateMonster(Monster monster)
        {
            return PostGen(monster);
        }

        // DELETE: api/Monster/5
        [HttpDelete("{id}")]
        public ActionResult<Monster> DeleteMonster(Guid id)
        {
            return DeleteGen(id);
        }

        // [HttpGet("[action]")]
        // public ActionResult<dynamic> GetTable([FromQuery] ListingParameters<Monster> query)
        // {
        //     dynamic monsters = UnitOfWork.Repository.Get(query)
        //         .Select(m => new
        //         {
        //             id = m.Id,
        //             name = m.Name,
        //             passivePerception = m.PassivePerception,
        //             alignment = m.Alignment
        //         }).ToList();
        //     return monsters;
        // }

        [HttpGet("[action]/{name}")]
        public ActionResult<List<string>> GetEnum(string name)
        {
            return GetEnumGen(name);
        }
    }
}
