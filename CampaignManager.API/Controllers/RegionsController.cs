using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CampaignManager.Data.Repositories;
using Microsoft.AspNetCore.JsonPatch;
using System;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using CampaignManager.API.ModelBinder;
using CampaignManager.Data.Model.Auth;
using CampaignManager.Data.Model.Locations;
using CampaignManager.API.Model.Auth;
using AutoMapper;
using CampaignManager.API.Model.Locations;

namespace CampaignManager.API.Controllers
{
    [Route("{campaignId}/[controller]"), Authorize]
    [ApiController]
    public class RegionsController : CampaignContextController<Region>
    {
        public RegionsController(IConfiguration configuration, IMapper mapper) : base(configuration, mapper) { }

        // GET: api/Regions
        [HttpGet]
        public IEnumerable<RegionDto> GetRegions(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] AccountDto user,
            Guid campaignId, [FromQuery] ListingFilterParameters<Region> query)
        {
            return Mapper.Map<List<RegionDto>>(GetGen(user.Id, campaignId, query));
        }

        // GET: api/Region/5
        [HttpGet("{regionId}")]
        public RegionDto GetRegionById(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] AccountDto user,
            Guid campaignId, Guid regionId, [FromQuery] FilterParameters<Region> query)
        {
            return Mapper.Map<RegionDto>(GetGenById(user.Id, campaignId, regionId, query));
        }

        [HttpPatch("{regionId}")]
        public RegionDto UpdateRegion(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] AccountDto user,
            Guid campaignId, Guid regionId, [FromBody] JsonPatchDocument<Region> patchDoc, [FromQuery] FilterParameters<Region> query)
        {
            return Mapper.Map<RegionDto>(PatchGen(user.Id, campaignId, regionId, patchDoc, query));
        }

        // PUT: api/Region/5
        [HttpPut("{regionId}")]
        public IActionResult UpdateRegion(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] AccountDto user,
            Guid campaignId, Guid regionId, RegionDto region)
        {
            return PutGen(user.Id, campaignId, regionId, Mapper.Map<Region>(region));
        }

        // POST: api/Region
        [HttpPost]
        [ProducesResponseType(201)]
        public ActionResult<Guid> CreateRegion(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] AccountDto user,
            Guid campaignId, RegionDto region)
        {
            return PostGen(user.Id, campaignId, Mapper.Map<Region>(region));
        }

        // DELETE: api/Region/5
        [HttpDelete("{regionId}")]
        public RegionDto DeleteRegion(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] AccountDto user,
            Guid campaignId, Guid regionId)
        {
            return Mapper.Map<RegionDto>(DeleteGen(user.Id, campaignId, regionId));
        }

        [HttpGet("[action]/{name}")]
        public ActionResult<List<string>> GetEnum(string name)
        {
            return GetEnumGen(name);
        }
    }
}
