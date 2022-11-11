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
    public class ContinentsController : GenericController<Continent>
    {
        // GET: api/Continent
        [HttpGet]
        public ActionResult<List<Continent>> GetContinents([FromQuery] string include)
        {
            return UnitOfWork.Repository.Get(includeProperties: include?.Split(',')).ToList();
        }

        // GET: api/Continent/5
        [HttpGet("{id}")]
        public ActionResult<Continent> GetContinentById(Guid id, [FromQuery] string include)
        {
            return GetGen(id, include);
        }

        [HttpPatch("{id}")]
        public ActionResult<Continent> PatchContinent(Guid id, [FromBody] JsonPatchDocument<Continent> patchDoc, [FromQuery] string include)
        {
            return PatchGen(id, patchDoc, include);
        }

        // PUT: api/Continent/5
        [HttpPut("{id}")]
        public IActionResult PutContinent(Guid id, Continent continent)
        {
            return PutGen(id, continent);
        }

        // POST: api/Continent
        [HttpPost]
        public ActionResult<Continent> PostContinent(Continent continent)
        {
            return PostGen(continent);
        }

        // DELETE: api/Continent/5
        [HttpDelete("{id}")]
        public ActionResult<Continent> DeleteContinent(Guid id)
        {
            return DeleteGen(id);
        }

        [HttpGet("[action]")]
        public ActionResult<dynamic> GetTable()
        {
            dynamic continents = UnitOfWork.Repository.Get()
                .Select(m => new
                {
                    id = m.Id,
                    name = m.Name
                }).ToList();
            return continents;
        }

        [HttpGet("[action]/{name}")]
        public ActionResult<List<string>> GetEnum(string name)
        {
            return GetEnumGen(name);
        }
    }
}
