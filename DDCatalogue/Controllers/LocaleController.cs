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
    public class LocaleController : GenericController<Locale>
    {
        [HttpGet("{id}")]
        public ActionResult<Locale> GetLocale(int id, [FromQuery] string include)
        {
            return GetGen(id, include);
        }
    }
}
