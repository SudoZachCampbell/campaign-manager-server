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
using CampaignManager.API.Model.Auth;
using AutoMapper;
using CampaignManager.API.Model.Locations;

namespace CampaignManager.API.Controllers
{
    [Route("{campaignId}/[controller]"), Authorize]
    [ApiController]
    public class LocalesController : CampaignContextController<Locale>
    {
        public LocalesController(IConfiguration configuration, IMapper mapper) : base(configuration, mapper) { }

        // GET: api/Locales
        [HttpGet]
        public IEnumerable<LocaleDto> GetLocales(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] AccountDto user,
            Guid campaignId, [FromQuery] ListingFilterParameters<Locale> query)
        {
            return Mapper.Map<IEnumerable<LocaleDto>>(GetGen(user.Id, campaignId, query));
        }

        // GET: api/Locale/5
        [HttpGet("{localeId}")]
        public LocaleDto GetLocaleById(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] AccountDto user,
            Guid campaignId, Guid localeId, [FromQuery] FilterParameters<Locale> query)
        {
            return Mapper.Map<LocaleDto>(GetGenById(user.Id, campaignId, localeId, query));
        }

        [HttpPatch("{localeId}")]
        public LocaleDto UpdateLocale(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] AccountDto user,
            Guid campaignId, Guid localeId, [FromBody] JsonPatchDocument<Locale> patchDoc, [FromQuery] FilterParameters<Locale> query)
        {
            return Mapper.Map<LocaleDto>(PatchGen(user.Id, campaignId, localeId, patchDoc, query));
        }

        // PUT: api/Locale/5
        [HttpPut("{localeId}")]
        public IActionResult UpdateLocale(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] AccountDto user,
            Guid campaignId, Guid localeId, LocaleDto locale)
        {
            return PutGen(user.Id, campaignId, localeId, Mapper.Map<Locale>(locale));
        }

        // POST: api/Locale
        [HttpPost]
        [ProducesResponseType(201)]
        public ActionResult<Guid> CreateLocale(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] AccountDto user,
            Guid campaignId, LocaleDto locale)
        {
            return PostGen(user.Id, campaignId, Mapper.Map<Locale>(locale));
        }

        // DELETE: api/Locale/5
        [HttpDelete("{localeId}")]
        public LocaleDto DeleteLocale(
            [FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] AccountDto user,
            Guid campaignId, Guid localeId)
        {
            return Mapper.Map<LocaleDto>(DeleteGen(user.Id, campaignId, localeId));
        }

        [HttpGet("[action]/{name}")]
        public ActionResult<List<string>> GetEnum(string name)
        {
            return GetEnumGen(name);
        }

        // GET: api/Region
        [HttpGet("Region/{regionId}")]
        public List<LocaleDto> GetRegionsFromContinent([FromHeader(Name = "Authorization")][ModelBinder((typeof(AccountModelBinder)))] AccountDto user, int regionId, [FromQuery] ListingFilterParameters<Locale> parameters)
        {
            parameters.Filter = $"regionId|eq|{regionId}";
            return Mapper.Map<List<LocaleDto>>(UnitOfWork.Repository.Get(user.Id, parameters).ToList());
        }
    }
}



