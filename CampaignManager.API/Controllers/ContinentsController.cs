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
    public class ContinentsController : CampaignContextController<Continent>
    {
        public ContinentsController(IConfiguration configuration) : base(configuration) { }

        // GET: api/Continents
        [HttpGet]
        public ActionResult<IEnumerable<Continent>> GetContinents(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] Account user,
            Guid campaignId, [FromQuery] ListingFilterParameters<Continent> query)
        {
            return GetGen(user.Id, campaignId, query);
        }

        // GET: api/Continent/5
        [HttpGet("{continentId}")]
        public ActionResult<Continent> GetContinentById(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] Account user,
            Guid campaignId, Guid continentId, [FromQuery] FilterParameters<Continent> query)
        {
            return GetGenById(user.Id, campaignId, continentId, query);
        }

        [HttpPatch("{continentId}")]
        public ActionResult<Continent> UpdateContinent(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] Account user,
            Guid campaignId, Guid continentId, [FromBody] JsonPatchDocument<Continent> patchDoc, [FromQuery] FilterParameters<Continent> query)
        {
            return PatchGen(user.Id, campaignId, continentId, patchDoc, query);
        }

        // PUT: api/Continent/5
        [HttpPut("{continentId}")]
        public IActionResult UpdateContinent(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] Account user,
            Guid campaignId, Guid continentId, Continent continent)
        {
            return PutGen(user.Id, campaignId, continentId, continent);
        }

        // POST: api/Continent
        [HttpPost]
        [ProducesResponseType(201)]
        public ActionResult<Guid> CreateContinent(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] Account user,
            Guid campaignId, Continent continent)
        {
            return PostGen(user.Id, campaignId, continent);
        }

        // DELETE: api/Continent/5
        [HttpDelete("{continentId}")]
        public ActionResult<Continent> DeleteContinent(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] Account user,
            Guid campaignId, Guid continentId)
        {
            return DeleteGen(user.Id, campaignId, continentId);
        }

        [HttpGet("[action]/{name}")]
        public ActionResult<List<string>> GetEnum(string name)
        {
            return GetEnumGen(name);
        }
    }
}
