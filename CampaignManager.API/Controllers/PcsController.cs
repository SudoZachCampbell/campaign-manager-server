using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CampaignManager.Data.Contexts;
using CampaignManager.Data.Model.Creatures;
using CampaignManager.Data.Repositories;
using Microsoft.AspNetCore.JsonPatch;
using System;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using CampaignManager.API.ModelBinder;
using CampaignManager.Data.Model.Auth;
using CampaignManager.API.Model.Auth;
using AutoMapper;
using CampaignManager.API.Model.Creatures;

namespace CampaignManager.API.Controllers
{
    [Route("{campaignId}/[controller]"), Authorize]
    [ApiController]
    public class PcsController : CampaignContextController<Pc>
    {
        public PcsController(IConfiguration configuration, IMapper mapper) : base(configuration, mapper) { }

        // GET: api/Pcs
        [HttpGet]
        public IEnumerable<PcDto> GetPcs(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] AccountDto user,
            Guid campaignId, [FromQuery] ListingFilterParameters<Pc> query)
        {
            return Mapper.Map<IEnumerable<PcDto>>(GetGen(user.Id, campaignId, query));
        }

        // GET: api/Pc/5
        [HttpGet("{pcId}")]
        public PcDto GetPcById(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] AccountDto user,
            Guid campaignId, Guid pcId, [FromQuery] FilterParameters<Pc> query)
        {
            return Mapper.Map<PcDto>(GetGenById(user.Id, campaignId, pcId, query));
        }

        [HttpPatch("{pcId}")]
        public PcDto UpdatePc(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] AccountDto user,
            Guid campaignId, Guid pcId, [FromBody] JsonPatchDocument<Pc> patchDoc, [FromQuery] FilterParameters<Pc> query)
        {
            return Mapper.Map<PcDto>(PatchGen(user.Id, campaignId, pcId, patchDoc, query));
        }

        // PUT: api/Pc/5
        [HttpPut("{pcId}")]
        public IActionResult UpdatePc(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] AccountDto user,
            Guid campaignId, Guid pcId, PcDto pc)
        {
            return PutGen(user.Id, campaignId, pcId, Mapper.Map<Pc>(pc));
        }

        // POST: api/Pc
        [HttpPost]
        [ProducesResponseType(201)]
        public ActionResult<Guid> CreatePc(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] AccountDto user,
            Guid campaignId, PcDto pc)
        {
            return PostGen(user.Id, campaignId, Mapper.Map<Pc>(pc));
        }

        // DELETE: api/Pc/5
        [HttpDelete("{pcId}")]
        public PcDto DeletePc(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] AccountDto user,
            Guid campaignId, Guid pcId)
        {
            return Mapper.Map<PcDto>(DeleteGen(user.Id, campaignId, pcId));
        }

        [HttpGet("[action]/{name}")]
        public ActionResult<List<string>> GetEnum(string name)
        {
            return GetEnumGen(name);
        }
    }
}
