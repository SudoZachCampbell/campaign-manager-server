using DDCatalogue.Model;
using DDCatalogue.Model.Creatures;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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

        [HttpGet]
        public ActionResult<string> Get(int id)
        {
            using DDContext db = new DDContext();
            return JsonConvert.SerializeObject(db.Npcs.Where(n => n.Id.Equals(id))
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

        [HttpGet("[action]")]
        public ActionResult<string> Table()
        {
            using DDContext db = new DDContext();
            JArray headers = new JArray(new string[] { "ID", "Name", "Monster", "Location" });
            JArray data = JArray.FromObject(db.Npcs.Include(n => n.Monster)
                                     .Include(n => n.Building)
                                     .Include(n => n.Locale)
                                     .Select(n => new { npcId = n.Id, npcName = n.Name, monsterName = n.Monster.Name, buildingName = n.Building.Name, localeName = n.Locale.Name })
                                     .ToList(),
                                     JsonSerializer.Create(new JsonSerializerSettings
                                     {
                                         ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                                     }));
            return new JObject()
            {
                ["headers"] = headers,
                ["data"] = data
            }.ToString();
        }
    }
}
