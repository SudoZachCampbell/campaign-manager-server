using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DDCatalogue.Model.Locations;
using Microsoft.AspNetCore.Mvc;

namespace DDCatalogue.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LocalesController : GenericController<Locale>
    {
        [HttpGet("{id}")]
        public ActionResult<Locale> GetLocale(Guid id, [FromQuery] string include)
        {
            return GetGen(id, include);
        }

        // GET: api/Region
        [HttpGet("Region/{regionId}")]
        public ActionResult<List<Locale>> GetRegionsFromContinent(int regionId, [FromQuery] string include)
        {
            return UnitOfWork.Repository.Get(x => x.Region.Id.Equals(regionId), includeProperties: include?.Split(',')).ToList();
        }
    }
}
