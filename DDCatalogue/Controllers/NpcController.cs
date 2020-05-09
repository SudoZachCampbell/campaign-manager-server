using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DDCatalogue.Model;
using DDCatalogue.Model.Creatures;
using Microsoft.Extensions.Logging;

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
        public IEnumerable<Npc> Get()
        {
            using(DDContext db = new DDContext())
            {
                return db.Npcs.ToList();
            }
        }
    }
}
