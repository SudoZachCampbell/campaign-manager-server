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
    public class ContinentsController : CampaignContextController<Continent>
    {
        public ContinentsController(IConfiguration configuration, IMapper mapper) : base(configuration, mapper) { }

        // GET: api/Continents
        [HttpGet]
        public IEnumerable<ContinentDto> GetContinents(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] AccountDto user,
            Guid campaignId, [FromQuery] ListingFilterParameters<Continent> query)
        {
            return Mapper.Map<IEnumerable<ContinentDto>>(GetGen(user.Id, campaignId, query));
        }

        // GET: api/Continent/5
        [HttpGet("{continentId}")]
        public ContinentDto GetContinentById(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] AccountDto user,
            Guid campaignId, Guid continentId, [FromQuery] FilterParameters<Continent> query)
        {
            return Mapper.Map<ContinentDto>(GetGenById(user.Id, campaignId, continentId, query));
        }

        [HttpPatch("{continentId}")]
        public ContinentDto UpdateContinent(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] AccountDto user,
            Guid campaignId, Guid continentId, [FromBody] JsonPatchDocument<Continent> patchDoc, [FromQuery] FilterParameters<Continent> query)
        {
            return Mapper.Map<ContinentDto>(PatchGen(user.Id, campaignId, continentId, patchDoc, query));
        }

        // PUT: api/Continent/5
        [HttpPut("{continentId}")]
        public IActionResult UpdateContinent(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] AccountDto user,
            Guid campaignId, Guid continentId, ContinentDto continent)
        {
            return PutGen(user.Id, campaignId, continentId, Mapper.Map<Continent>(continent));
        }

        // POST: api/Continent
        [HttpPost]
        [ProducesResponseType(201)]
        public ActionResult<Guid> CreateContinent(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] AccountDto user,
            Guid campaignId, ContinentDto continent)
        {
            return PostGen(user.Id, campaignId, Mapper.Map<Continent>(continent));
        }

        // DELETE: api/Continent/5
        [HttpDelete("{continentId}")]
        public ContinentDto DeleteContinent(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] AccountDto user,
            Guid campaignId, Guid continentId)
        {
            return Mapper.Map<ContinentDto>(DeleteGen(user.Id, campaignId, continentId));
        }

        [HttpGet("[action]/{name}")]
        public ActionResult<List<string>> GetEnum(string name)
        {
            return GetEnumGen(name);
        }
    }
}
