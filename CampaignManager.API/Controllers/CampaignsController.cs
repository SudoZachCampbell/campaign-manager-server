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
using CampaignManager.API.Model.Auth;
using AutoMapper;
using Amazon.S3.Model;
using CampaignManager.API.Model.Games;

namespace CampaignManager.API.Controllers
{
    [Route("[controller]"), Authorize]
    [ApiController]
    public class CampaignsController : GenericController<Campaign>
    {
        public CampaignsController(IConfiguration configuration, IMapper mapper) : base(configuration, mapper) { }

        // GET: api/campaign
        [HttpGet]
        public List<CampaignDto> GetCampaigns(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] AccountDto user,
            [FromQuery] ListingFilterParameters<Campaign> query)
        {
            return Mapper.Map<List<CampaignDto>>(GetGen(user.Id, query));
        }

        // GET: api/campaign/5
        [HttpGet("{id}")]
        public CampaignDto GetCampaignById(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] AccountDto user,
            Guid id, [FromQuery] FilterParameters<Campaign> query)
        {
            return Mapper.Map<CampaignDto>(GetGen(user.Id, id, query));
        }

        [HttpPatch("{id}")]
        public CampaignDto UpdateCampaign(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] AccountDto user,
            Guid id, [FromBody] JsonPatchDocument<Campaign> patchDoc, [FromQuery] FilterParameters<Campaign> query)
        {
            return Mapper.Map<CampaignDto>(PatchGen(user.Id, id, patchDoc, query));
        }

        // PUT: api/campaign/5
        [HttpPut("{id}")]
        public IActionResult UpdateCampaign(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] AccountDto user,
            Guid id, CampaignDto monster)
        {
            return PutGen(user.Id, id, Mapper.Map<Campaign>(monster));
        }

        // POST: api/campaign
        [HttpPost]
        [ProducesResponseType(201)]
        public ActionResult<Guid> CreateCampaign(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] AccountDto user,
            CampaignDto campaign)
        {
            campaign.OwnerId = user.Id;
            return PostGen(user.Id, Mapper.Map<Campaign>(campaign));
        }

        // DELETE: api/campaign/5
        [HttpDelete("{id}")]
        public CampaignDto DeleteCampaign(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] AccountDto user,
            Guid id)
        {
            return Mapper.Map<CampaignDto>(DeleteGen(user.Id, id));
        }

        [HttpGet("[action]/{name}")]
        public ActionResult<List<string>> Enum(string name)
        {
            return GetEnumGen(name);
        }
    }
}
