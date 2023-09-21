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

namespace CampaignManager.API.Controllers
{
    [Route("{campaignId}/[controller]"), Authorize]
    [ApiController]
    public class RegionsController : CampaignContextController<Region>
    {
        public RegionsController(IConfiguration configuration) : base(configuration) { }

        // GET: api/Regions
        [HttpGet]
        public ActionResult<IEnumerable<Region>> GetRegions(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] Account user,
            Guid campaignId, [FromQuery] ListingFilterParameters<Region> query)
        {
            return GetGen(user.Id, campaignId, query);
        }

        // GET: api/Region/5
        [HttpGet("{regionId}")]
        public ActionResult<Region> GetRegionById(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] Account user,
            Guid campaignId, Guid regionId, [FromQuery] FilterParameters<Region> query)
        {
            return GetGenById(user.Id, campaignId, regionId, query);
        }

        [HttpPatch("{regionId}")]
        public ActionResult<Region> UpdateRegion(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] Account user,
            Guid campaignId, Guid regionId, [FromBody] JsonPatchDocument<Region> patchDoc, [FromQuery] FilterParameters<Region> query)
        {
            return PatchGen(user.Id, campaignId, regionId, patchDoc, query);
        }

        // PUT: api/Region/5
        [HttpPut("{regionId}")]
        public IActionResult UpdateRegion(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] Account user,
            Guid campaignId, Guid regionId, Region region)
        {
            return PutGen(user.Id, campaignId, regionId, region);
        }

        // POST: api/Region
        [HttpPost]
        [ProducesResponseType(201)]
        public ActionResult<Guid> CreateRegion(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] Account user,
            Guid campaignId, Region region)
        {
            return PostGen(user.Id, campaignId, region);
        }

        // DELETE: api/Region/5
        [HttpDelete("{regionId}")]
        public ActionResult<Region> DeleteRegion(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] Account user,
            Guid campaignId, Guid regionId)
        {
            return DeleteGen(user.Id, campaignId, regionId);
        }

        [HttpGet("[action]/{name}")]
        public ActionResult<List<string>> GetEnum(string name)
        {
            return GetEnumGen(name);
        }
    }
}
