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
    public class CampaignsController : GenericController<Campaign>
    {
        public CampaignsController(IConfiguration configuration) : base(configuration) { }

        // GET: api/campaign
        [HttpGet]
        public ActionResult<List<Campaign>> GetCampaigns(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] Account user,
            [FromQuery] ListingFilterParameters<Campaign> query)
        {
            return GetGen(user.Id, query);
        }

        // GET: api/campaign/5
        [HttpGet("{id}")]
        public ActionResult<Campaign> GetCampaignById(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] Account user,
            Guid id, [FromQuery] FilterParameters<Campaign> query)
        {
            return GetGen(user.Id, id, query);
        }

        [HttpPatch("{id}")]
        public ActionResult<Campaign> UpdateCampaign(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] Account user,
            Guid id, [FromBody] JsonPatchDocument<Campaign> patchDoc, [FromQuery] FilterParameters<Campaign> query)
        {
            return PatchGen(user.Id, id, patchDoc, query);
        }

        // PUT: api/campaign/5
        [HttpPut("{id}")]
        public IActionResult UpdateCampaign(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] Account user,
            Guid id, Campaign monster)
        {
            return PutGen(user.Id, id, monster);
        }

        // POST: api/campaign
        [HttpPost]
        [ProducesResponseType(201)]
        public ActionResult<Guid> CreateCampaign(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] Account user,
            Campaign campaign)
        {
            campaign.OwnerId = user.Id;
            return PostGen(user.Id, campaign);
        }

        // DELETE: api/campaign/5
        [HttpDelete("{id}")]
        public ActionResult<Campaign> DeleteCampaign(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] Account user,
            Guid id)
        {
            return DeleteGen(user.Id, id);
        }

        [HttpGet("[action]/{name}")]
        public ActionResult<List<string>> Enum(string name)
        {
            return GetEnumGen(name);
        }
    }
}
