using CampaignManager.Data.Model.Games;
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
    public class CampaignsController : OwnedController<Campaign>
    {
        public CampaignsController(IConfiguration configuration) : base(configuration) { }

        // GET: api/campaign
        [HttpGet]
        public ActionResult<List<Campaign>> GetCampaigns(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] Account user,
            [FromQuery] ListingFilterParameters<Campaign> query)
        {
            return GetGenOwned(user, query);
        }

        // GET: api/campaign/5
        [HttpGet("{id}")]
        public ActionResult<Campaign> GetCampaignById(Guid id, [FromQuery] FilterParameters<Campaign> query)
        {
            return GetGen(id, query);
        }

        [HttpPatch("{id}")]
        public ActionResult<Campaign> UpdateCampaign(Guid id, [FromBody] JsonPatchDocument<Campaign> patchDoc, [FromQuery] FilterParameters<Campaign> query)
        {
            return PatchGen(id, patchDoc, query);
        }

        // PUT: api/campaign/5
        [HttpPut("{id}")]
        public IActionResult UpdateCampaign(Guid id, Campaign monster)
        {
            return PutGen(id, monster);
        }

        // POST: api/campaign
        [HttpPost]
        public ActionResult<Campaign> CreateCampaign(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] Account user,
            Campaign campaign)
        {
            campaign.OwnerId = user.Id;
            return PostGen(campaign);
        }

        // DELETE: api/campaign/5
        [HttpDelete("{id}")]
        public ActionResult<Campaign> DeleteCampaign(Guid id)
        {
            return DeleteGen(id);
        }

        [HttpGet("[action]/{name}")]
        public ActionResult<List<string>> Enum(string name)
        {
            return GetEnumGen(name);
        }
    }
}
