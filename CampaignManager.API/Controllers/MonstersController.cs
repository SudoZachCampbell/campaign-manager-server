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
using CampaignManager.API.Model.Auth;
using CampaignManager.API.Model.Creatures;
using AutoMapper;

namespace CampaignManager.API.Controllers
{
    [Route("[controller]"), Authorize]
    [ApiController]
    public class MonstersController : GenericController<Monster>
    {
        public MonstersController(IConfiguration configuration, IMapper mapper) : base(configuration, mapper) { }

        // GET: api/Monster
        [HttpGet]
        public List<MonsterDto> GetMonsters(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] AccountDto user,
            [FromQuery] ListingFilterParameters<Monster> query)
        {
            return Mapper.Map<List<MonsterDto>>(GetGen(user.Id, query));
        }

        // GET: api/Monster/5
        [HttpGet("{id}")]
        public MonsterDto GetMonsterById(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] AccountDto user,
            Guid id, [FromQuery] FilterParameters<Monster> query)
        {
            return Mapper.Map<MonsterDto>(GetGen(user.Id, id, query));
        }

        [HttpPatch("{id}")]
        public MonsterDto UpdateMonster(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] AccountDto user,
            Guid id, [FromBody] JsonPatchDocument<Monster> patchDoc, [FromQuery] FilterParameters<Monster> query)
        {
            return Mapper.Map<MonsterDto>(PatchGen(user.Id, id, patchDoc, query));
        }

        // PUT: api/Monster/5
        [HttpPut("{id}")]
        public IActionResult UpdateMonster(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] AccountDto user,
            Guid id, MonsterDto monster)
        {
            return PutGen(user.Id, id, Mapper.Map<Monster>(monster));
        }

        // POST: api/Monster
        [HttpPost]
        [ProducesResponseType(201)]
        public ActionResult<Guid> CreateMonster(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] AccountDto user,
            MonsterDto monster)
        {
            monster.OwnerId = user.Id;
            try
            {
                return PostGen(user.Id, Mapper.Map<Monster>(monster));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // DELETE: api/Monster/5
        [HttpDelete("{id}")]
        public MonsterDto DeleteMonster(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] AccountDto user,
            Guid id)
        {
            return Mapper.Map<MonsterDto>(DeleteGen(user.Id, id));
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
