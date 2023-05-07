﻿using System;
using System.Collections.Generic;
using System.Linq;
using CampaignManager.Data.Model.Locations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using CampaignManager.Data.Repositories;

namespace CampaignManager.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LocalesController : GenericController<Locale>
    {
        public LocalesController(IConfiguration configuration) : base(configuration) { }

        [HttpGet("{id}")]
        public ActionResult<Locale> GetLocale(Guid id, [FromQuery] string include)
        {
            return GetGen(id, include);
        }

        // GET: api/Region
        [HttpGet("Region/{regionId}")]
        public ActionResult<List<Locale>> GetRegionsFromContinent(int regionId, [FromQuery] FilterParameters<Locale> parameters)
        {
            parameters.Filter = $"regionId|eq|{regionId}";
            return UnitOfWork.Repository.Get(parameters).ToList();
        }
    }
}
