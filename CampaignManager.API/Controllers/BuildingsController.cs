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
    public class BuildingsController : GenericController<Building>
    {
        public BuildingsController(IConfiguration configuration) : base(configuration) { }

        // GET: api/Building
        [HttpGet("Locale/{localeId}")]
        public ActionResult<List<Building>> GetBuildingsFromLocale(Guid localeId, [FromQuery] ListingFilterParameters<Building> parameters)
        {
            parameters.Filter = $"localId|eq|{localeId}";
            return UnitOfWork.Repository.Get(parameters).ToList();
        }

        // GET: api/Building/5
        [HttpGet("{id}")]
        public ActionResult<Building> GetBuildingById(Guid id, [FromQuery] FilterParameters<Building> query)
        {
            return GetGen(id, query);
        }

        [HttpPatch("{id}")]
        public ActionResult<Building> PatchBuilding(Guid id, [FromBody] JsonPatchDocument<Building> patchDoc, [FromQuery] FilterParameters<Building> query)
        {
            return PatchGen(id, patchDoc, query);
        }

        // PUT: api/Building/5
        [HttpPut("{id}")]
        public IActionResult PutBuilding(Guid id, Building building)
        {
            return PutGen(id, building);
        }

        // POST: api/Building
        [HttpPost]
        public ActionResult<Building> PostBuilding(Building building)
        {
            return PostGen(building);
        }

        // DELETE: api/Building/5
        [HttpDelete("{id}")]
        public ActionResult<Building> DeleteBuilding(Guid id)
        {
            return DeleteGen(id);
        }

        // [HttpGet("[action]")]
        // public ActionResult<dynamic> GetTable()
        // {
        //     dynamic buildings = UnitOfWork.Repository.Get()
        //         .Select(m => new
        //         {
        //             id = m.Id,
        //             name = m.Name
        //         }).ToList();
        //     return buildings;
        // }

        [HttpGet("[action]/{name}")]
        public ActionResult<List<string>> GetEnum(string name)
        {
            return GetEnumGen(name);
        }
    }
}
