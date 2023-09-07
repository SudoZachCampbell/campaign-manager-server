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
    [Route("[controller]"), Authorize]
    [ApiController]
    public class PcsController : GenericController<Pc>
    {
        public PcsController(IConfiguration configuration) : base(configuration) { }

        // GET: api/Pcs
        [HttpGet]
        public ActionResult<List<Pc>> GetPcs([FromQuery] ListingFilterParameters<Pc> query)
        {
            return GetGen(query);
        }

        // GET: api/Pc/5
        [HttpGet("{id}")]
        public ActionResult<Pc> GetPcById(Guid id, [FromQuery] FilterParameters<Pc> query)
        {
            return GetGen(id, query);
        }

        [HttpPatch("{id}")]
        public ActionResult<Pc> UpdatePc(Guid id, [FromBody] JsonPatchDocument<Pc> patchDoc, [FromQuery] FilterParameters<Pc> query)
        {
            return PatchGen(id, patchDoc, query);
        }

        // PUT: api/Pc/5
        [HttpPut("{id}")]
        public IActionResult UpdatePc(Guid id, Pc pc)
        {
            return PutGen(id, pc);
        }

        // POST: api/Pc
        [HttpPost]
        [ProducesResponseType(201)]
        public ActionResult<Guid> CreatePc(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] Account user,
            Pc pc)
        {
            pc.OwnerId = user.Id;
            return PostGen(pc);
        }

        // DELETE: api/Pc/5
        [HttpDelete("{id}")]
        public ActionResult<Pc> DeletePc(Guid id)
        {
            return DeleteGen(id);
        }

        [HttpGet("[action]/{name}")]
        public ActionResult<List<string>> GetEnum(string name)
        {
            return GetEnumGen(name);
        }
    }
}
