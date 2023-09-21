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
using System.Linq;

namespace CampaignManager.API.Controllers
{
    [Route("{campaignId}/[controller]"), Authorize]
    [ApiController]
    public class LocalesController : CampaignContextController<Locale>
    {
        public LocalesController(IConfiguration configuration) : base(configuration) { }

        // GET: api/Locales
        [HttpGet]
        public ActionResult<IEnumerable<Locale>> GetLocales(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] Account user,
            Guid campaignId, [FromQuery] ListingFilterParameters<Locale> query)
        {
            return GetGen(user.Id, campaignId, query);
        }

        // GET: api/Locale/5
        [HttpGet("{localeId}")]
        public ActionResult<Locale> GetLocaleById(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] Account user,
            Guid campaignId, Guid localeId, [FromQuery] FilterParameters<Locale> query)
        {
            return GetGenById(user.Id, campaignId, localeId, query);
        }

        [HttpPatch("{localeId}")]
        public ActionResult<Locale> UpdateLocale(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] Account user,
            Guid campaignId, Guid localeId, [FromBody] JsonPatchDocument<Locale> patchDoc, [FromQuery] FilterParameters<Locale> query)
        {
            return PatchGen(user.Id, campaignId, localeId, patchDoc, query);
        }

        // PUT: api/Locale/5
        [HttpPut("{localeId}")]
        public IActionResult UpdateLocale(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] Account user,
            Guid campaignId, Guid localeId, Locale locale)
        {
            return PutGen(user.Id, campaignId, localeId, locale);
        }

        // POST: api/Locale
        [HttpPost]
        [ProducesResponseType(201)]
        public ActionResult<Guid> CreateLocale(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] Account user,
            Guid campaignId, Locale locale)
        {
            return PostGen(user.Id, campaignId, locale);
        }

        // DELETE: api/Locale/5
        [HttpDelete("{localeId}")]
        public ActionResult<Locale> DeleteLocale(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] Account user,
            Guid campaignId, Guid localeId)
        {
            return DeleteGen(user.Id, campaignId, localeId);
        }

        [HttpGet("[action]/{name}")]
        public ActionResult<List<string>> GetEnum(string name)
        {
            return GetEnumGen(name);
        }

        // GET: api/Region
        [HttpGet("Region/{regionId}")]
        public ActionResult<List<Locale>> GetRegionsFromContinent([FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] Account user, int regionId, [FromQuery] ListingFilterParameters<Locale> parameters)
        {
            parameters.Filter = $"regionId|eq|{regionId}";
            return UnitOfWork.Repository.Get(user.Id, parameters).ToList();
        }
    }
}



