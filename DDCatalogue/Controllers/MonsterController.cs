using DDCatalogue.Model;
using DDCatalogue.Model.Creatures;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDCatalogue.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonsterController : ControllerBase
    {
        private readonly DDContext db;

        public MonsterController(DDContext context)
        {
            db = context;
        }

        // GET: api/Monster
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Monster>>> GetMonsters()
        {
            return await db.Monsters.ToListAsync();
        }

        // GET: api/Monster/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Monster>> GetMonster(int id)
        {
            Monster monster = await db.Monsters.FindAsync(id);

            if (monster == null) return NotFound();

            return monster;
        }

        // PUT: api/Monster/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMonster(int id, Monster monster)
        {
            if (id != monster.Id)
            {
                return BadRequest();
            }

            db.Entry(monster).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MonsterExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Monster
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Monster>> PostMonster(Monster monster)
        {
            db.Monsters.Add(monster);
            await db.SaveChangesAsync();

            return CreatedAtAction("GetMonster", new { id = monster.Id }, monster);
        }

        // DELETE: api/Monster/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Monster>> DeleteMonster(int id)
        {
            var monster = await db.Monsters.FindAsync(id);
            if (monster == null)
            {
                return NotFound();
            }

            db.Monsters.Remove(monster);
            await db.SaveChangesAsync();

            return monster;
        }

        private bool MonsterExists(int id)
        {
            return db.Monsters.Any(e => e.Id == id);
        }

        [HttpGet("[action]")]
        public ActionResult<string> Table()
        {
            JArray headers = new JArray(new string[] { "ID", "Name", "Passive Perception", "Alignment" });
            JArray data = JArray.FromObject(db.Monsters
                                     .Select(m => new { id = m.Id, m.Name, m.Pp, m.Alignment })
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
