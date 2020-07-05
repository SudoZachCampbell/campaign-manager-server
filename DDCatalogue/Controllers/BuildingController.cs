using DDCatalogue.Model;
using DDCatalogue.Model.Creatures;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Linq.Expressions;
using DDCatalogue.Model.Locations;

namespace DDCatalogue.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BuildingController : GenericController<Building>
    {
        // GET: api/Monster
        [HttpGet("Locale/{name}")]
        public ActionResult<List<Building>> GetBuildingsFromLocale(string name, [FromQuery] string include)
        {
            return UnitOfWork.Repository.Get(x => x.Locale.Name.Equals(name), includeProperties: include?.Split(',')).ToList();
        }

        // GET: api/Monster/5
        [HttpGet("{id}")]
        public ActionResult<Building> GetBuildingById(int id, [FromQuery] string include)
        {
            return GetGen(id, include);
        }

        [HttpPatch("{id}")]
        public ActionResult<Building> PatchMonster(int id, [FromBody] JsonPatchDocument<Building> patchDoc, [FromQuery] string include)
        {
            return PatchGen(id, patchDoc, include);
        }

        // PUT: api/Monster/5
        [HttpPut("{id}")]
        public IActionResult PutMonster(int id, Building monster)
        {
            return PutGen(id, monster);
        }

        // POST: api/Monster
        [HttpPost]
        public ActionResult<Monster> PostMonster(Building monster)
        {
            return PostGen(monster);
        }

        // DELETE: api/Monster/5
        [HttpDelete("{id}")]
        public ActionResult<Building> DeleteMonster(int id)
        {
            return DeleteGen(id);
        }

        [HttpGet("[action]")]
        public ActionResult<dynamic> GetTable()
        {
            dynamic monsters = UnitOfWork.Repository.Get()
                .Select(m => new
                {
                    id = m.Id,
                    name = m.Name
                }).ToList();
            return monsters;
        }

        [HttpGet("[action]/{name}")]
        public ActionResult<List<string>> GetEnum(string name)
        {
            return GetEnumGen(name);
        }
    }
}
