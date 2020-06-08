using DDCatalogue.Model;
using DDCatalogue.Model.Creatures;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;


namespace DDCatalogue.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MonsterController : ControllerBase
    {
        private readonly UnitOfWork<Monster> UnitOfWork = new UnitOfWork<Monster>();

        // GET: api/Monster
        [HttpGet]
        public ActionResult<List<Monster>> Get([FromQuery] string include)
        {
            return UnitOfWork.Repository.Get(includeProperties: include?.Split(',')).ToList();
        }

        // GET: api/Monster/5
        [HttpGet("{id}")]
        public ActionResult<Monster> Get(int id, [FromQuery] string include)
        {
            Monster monster = UnitOfWork.Repository.GetById(id, includeProperties: include?.Split(','));

            if (monster == null) return NotFound();

            return monster;
        }

        [HttpPatch("{id}")]
        public ActionResult<Monster> Patch(int id, [FromBody] JsonPatchDocument<Monster> patchDoc, [FromQuery] string include)
        {
            if (patchDoc != null)
            {
                Monster monster = UnitOfWork.Repository.GetById(id, includeProperties: include?.Split(','));

                if (monster != null)
                {
                    patchDoc.ApplyTo(monster, ModelState);
                }
                else
                {
                    return BadRequest(ModelState);
                }

                UnitOfWork.Repository.Update(monster);
                UnitOfWork.Save();

                return monster;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // PUT: api/Monster/5
        [HttpPut("{id}")]
        public IActionResult PutMonster(int id, Monster monster)
        {
            if (id != monster.Id)
            {
                return BadRequest();
            }

            UnitOfWork.Repository.Update(monster);
            UnitOfWork.Save();

            return NoContent();
        }

        // POST: api/Monster
        [HttpPost]
        public ActionResult<Monster> PostMonster(Monster monster)
        {
            UnitOfWork.Repository.Insert(monster);
            UnitOfWork.Save();

            return CreatedAtAction("GetMonster", new { id = monster.Id }, monster);
        }

        // DELETE: api/Monster/5
        [HttpDelete("{id}")]
        public ActionResult<Monster> DeleteMonster(int id)
        {
            Monster monster = UnitOfWork.Repository.GetById(id);
            if (monster == null)
            {
                return NotFound();
            }

            UnitOfWork.Repository.Delete(monster);
            UnitOfWork.Save();

            return monster;
        }

        [HttpGet("[action]")]
        public ActionResult<dynamic> Table()
        {
            dynamic monsters = UnitOfWork.Repository.Get()
                .Select(m => new
                {
                    id = m.Id,
                    name = m.Name,
                    passivePerception = m.PassivePerception,
                    alignment = m.Alignment
                }).ToList();
            return monsters;
        }
    }
}
