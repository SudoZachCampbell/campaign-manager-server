﻿using Microsoft.AspNetCore.JsonPatch;
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
    public class RegionsController : GenericController<Region>
    {
        public RegionsController(IConfiguration configuration) : base(configuration) { }
        // GET: api/Region
        [HttpGet("Continent/{continentId}")]
        public ActionResult<List<Region>> GetRegionsFromContinent(Guid continentId, [FromQuery] ListingFilterParameters<Region> parameters)
        {
            parameters.Filter = $"continentId|eq|{continentId}";
            return UnitOfWork.Repository.Get(parameters).ToList();
        }

        // GET: api/Region/5
        [HttpGet("{id}")]
        public ActionResult<Region> GetRegionById(Guid id, [FromQuery] FilterParameters<Region> query)
        {
            return GetGen(id, query);
        }

        [HttpPatch("{id}")]
        public ActionResult<Region> PatchRegion(Guid id, [FromBody] JsonPatchDocument<Region> patchDoc, [FromQuery] FilterParameters<Region> query)
        {
            return PatchGen(id, patchDoc, query);
        }

        // PUT: api/Region/5
        [HttpPut("{id}")]
        public IActionResult PutRegion(Guid id, Region region)
        {
            return PutGen(id, region);
        }

        // POST: api/Region
        [HttpPost]
        public ActionResult<Region> PostRegion(Region region)
        {
            return PostGen(region);
        }

        // DELETE: api/Region/5
        [HttpDelete("{id}")]
        public ActionResult<Region> DeleteRegion(Guid id)
        {
            return DeleteGen(id);
        }

        // [HttpGet("[action]")]
        // public ActionResult<dynamic> GetTable()
        // {
        //     dynamic regions = UnitOfWork.Repository.Get()
        //         .Select(m => new
        //         {
        //             id = m.Id,
        //             name = m.Name
        //         }).ToList();
        //     return regions;
        // }

        [HttpGet("[action]/{name}")]
        public ActionResult<List<string>> GetEnum(string name)
        {
            return GetEnumGen(name);
        }
    }
}