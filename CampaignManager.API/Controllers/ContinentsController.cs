using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;
using CampaignManager.Data.Model.Locations;
using Microsoft.Extensions.Configuration;
using CampaignManager.Data.Repositories;

namespace CampaignManager.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ContinentsController : GenericController<Continent>
    {
        public ContinentsController(IConfiguration configuration) : base(configuration) { }

        // GET: api/Continent
        [HttpGet]
        public ActionResult<List<Continent>> GetContinents([FromQuery] ListingFilterParameters<Continent> parameters)
        {
            return UnitOfWork.Repository.Get(parameters).ToList();
        }

        // GET: api/Continent/5
        [HttpGet("{id}")]
        public ActionResult<Continent> GetContinentById(Guid id, [FromQuery] FilterParameters<Continent> query)
        {
            return GetGen(id, query);
        }

        [HttpPatch("{id}")]
        public ActionResult<Continent> PatchContinent(
            Guid id,
            [FromBody] JsonPatchDocument<Continent> patchDoc,
            [FromQuery] FilterParameters<Continent> query)
        {
            return PatchGen(id, patchDoc, query);
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

        // [HttpGet("[action]")]
        // public ActionResult<dynamic> GetTable()
        // {
        //     dynamic continents = UnitOfWork.Repository.Get()
        //         .Select(m => new
        //         {
        //             id = m.Id,
        //             name = m.Name
        //         }).ToList();
        //     return continents;
        // }

        [HttpGet("[action]/{name}")]
        public ActionResult<List<string>> GetEnum(string name)
        {
            return GetEnumGen(name);
        }
    }
}
