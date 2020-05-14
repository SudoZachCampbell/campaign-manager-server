using DDCatalogue.Model;
using DDCatalogue.Model.Creatures;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace DDCatalogue.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NpcController : ControllerBase
    {

        private readonly ILogger<NpcController> _logger;

        public NpcController(ILogger<NpcController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<string> Get()
        {
            using DDContext db = new DDContext();
            return JsonConvert.SerializeObject(db.Npcs
                                                .Include(n => n.Monster)
                                                .Include(n => n.Building)
                                                .Include(n => n.Locale)
                                                .ToList(),
                Formatting.Indented,
                new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
        }
    }
}
