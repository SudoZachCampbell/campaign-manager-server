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
namespace CampaignManager.API.Controllers
{
    [Route("{campaignId}/[controller]"), Authorize]
    [ApiController]
    public class PcsController : CampaignContextController<Pc>
    {
        public PcsController(IConfiguration configuration) : base(configuration) { }

        // GET: api/Pcs
        [HttpGet]
        public ActionResult<IEnumerable<Pc>> GetPcs(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] Account user,
            Guid campaignId, [FromQuery] ListingFilterParameters<Pc> query)
        {
            return GetGen(user.Id, campaignId, query);
        }

        // GET: api/Pc/5
        [HttpGet("{pcId}")]
        public ActionResult<Pc> GetPcById(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] Account user,
            Guid campaignId, Guid pcId, [FromQuery] FilterParameters<Pc> query)
        {
            return GetGenById(user.Id, campaignId, pcId, query);
        }

        [HttpPatch("{pcId}")]
        public ActionResult<Pc> UpdatePc(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] Account user,
            Guid campaignId, Guid pcId, [FromBody] JsonPatchDocument<Pc> patchDoc, [FromQuery] FilterParameters<Pc> query)
        {
            return PatchGen(user.Id, campaignId, pcId, patchDoc, query);
        }

        // PUT: api/Pc/5
        [HttpPut("{pcId}")]
        public IActionResult UpdatePc(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] Account user,
            Guid campaignId, Guid pcId, Pc pc)
        {
            return PutGen(user.Id, campaignId, pcId, pc);
        }

        // POST: api/Pc
        [HttpPost]
        [ProducesResponseType(201)]
        public ActionResult<Guid> CreatePc(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] Account user,
            Guid campaignId, Pc pc)
        {
            return PostGen(user.Id, campaignId, pc);
        }

        // DELETE: api/Pc/5
        [HttpDelete("{pcId}")]
        public ActionResult<Pc> DeletePc(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] Account user,
            Guid campaignId, Guid pcId)
        {
            return DeleteGen(user.Id, campaignId, pcId);
        }

        [HttpGet("[action]/{name}")]
        public ActionResult<List<string>> GetEnum(string name)
        {
            return GetEnumGen(name);
        }
    }
}
