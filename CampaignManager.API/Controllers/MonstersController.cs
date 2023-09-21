using CampaignManager.Data.Model.Creatures;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using CampaignManager.Data.Repositories;
using CampaignManager.API.ModelBinder;
using CampaignManager.Data.Model.Auth;

namespace CampaignManager.API.Controllers
{
    [Route("[controller]"), Authorize]
    [ApiController]
    public class MonstersController : GenericController<Monster>
    {
        public MonstersController(IConfiguration configuration) : base(configuration) { }

        // GET: api/Monster
        [HttpGet]
        public ActionResult<List<Monster>> GetMonsters(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] Account user,
            [FromQuery] ListingFilterParameters<Monster> query)
        {
            return GetGen(user.Id, query);
        }

        // GET: api/Monster/5
        [HttpGet("{id}")]
        public ActionResult<Monster> GetMonsterById(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] Account user,
            Guid id, [FromQuery] FilterParameters<Monster> query)
        {
            return GetGen(user.Id, id, query);
        }

        [HttpPatch("{id}")]
        public ActionResult<Monster> UpdateMonster(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] Account user,
            Guid id, [FromBody] JsonPatchDocument<Monster> patchDoc, [FromQuery] FilterParameters<Monster> query)
        {
            return PatchGen(user.Id, id, patchDoc, query);
        }

        // PUT: api/Monster/5
        [HttpPut("{id}")]
        public IActionResult UpdateMonster(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] Account user,
            Guid id, Monster monster)
        {
            return PutGen(user.Id, id, monster);
        }

        // POST: api/Monster
        [HttpPost]
        [ProducesResponseType(201)]
        public ActionResult<Guid> CreateMonster(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] Account user,
            Monster monster)
        {
            monster.OwnerId = user.Id;
            return PostGen(user.Id, monster);
        }

        // DELETE: api/Monster/5
        [HttpDelete("{id}")]
        public ActionResult<Monster> DeleteMonster(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] Account user,
            Guid id)
        {
            return DeleteGen(user.Id, id);
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
