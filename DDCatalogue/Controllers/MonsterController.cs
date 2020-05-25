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
    [Route("[controller]")]
    [ApiController]
    public class MonsterController : ControllerBase
    {
        private readonly UnitOfWork UnitOfWork = new UnitOfWork();

        // GET: api/Monster
        [HttpGet]
        public ActionResult<List<Monster>> GetMonsters()
        {
            return UnitOfWork.MonsterRepository.Get().ToList();
        }

        // GET: api/Monster/5
        [HttpGet("{id}")]
        public ActionResult<Monster> GetMonster(int id)
        {
            Monster monster = UnitOfWork.MonsterRepository.GetById(id);

            if (monster == null) return NotFound();

            return monster;
        }

        // PUT: api/Monster/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutMonster(int id, Monster monster)
        {
            if (id != monster.Id)
            {
                return BadRequest();
            }

            UnitOfWork.MonsterRepository.Update(monster);
            UnitOfWork.Save();

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
        public ActionResult<Monster> DeleteMonster(int id)
        {
            Monster monster = UnitOfWork.MonsterRepository.GetById(id);
            if (monster == null)
            {
                return NotFound();
            }

            UnitOfWork.MonsterRepository.Delete(monster);
            UnitOfWork.Save();

            return monster;
        }

        [HttpGet("[action]")]
        public ActionResult<List<Monster>> Table()
        {
            List<Monster> monsters = UnitOfWork.MonsterRepository.Get()
                .Select(m => new
                { 
                    m.Id, 
                    m.Name, 
                    m.PassivePerception, 
                    m.Alignment 
                })
                .ToListAsync();
            return monsters;
        }
    }
}
