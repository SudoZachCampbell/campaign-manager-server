using DDCatalogue.Model;
using DDCatalogue.Model.Creatures;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace DDCatalogue.Controllers
{
    public class GenericController<T> : ControllerBase where T : class, IBase
    {
        protected readonly UnitOfWork<T> UnitOfWork = new UnitOfWork<T>();

        [HttpGet("[action]")]
        public ActionResult<string> Status()
        {
            return "Running";
        }

        public ActionResult<List<T>> GetGen([FromQuery] string include)
        {
            return UnitOfWork.Repository.Get(includeProperties: include?.Split(',')).ToList();
        }

        public ActionResult<T> GetGen(Guid id, [FromQuery] string include)
        {
            T instance = UnitOfWork.Repository.GetById(id, includeProperties: include?.Split(','));

            if (instance == null) return NotFound();

            return instance;
        }

        public ActionResult<T> PatchGen(Guid id, [FromBody] JsonPatchDocument<T> patchDoc, [FromQuery] string include)
        {
            if (patchDoc != null)
            {
                string[] includeArray = include?.Split(',');
                T instance = UnitOfWork.Repository.GetById(id, includeProperties: includeArray);

                if (instance != null)
                {
                    patchDoc.ApplyTo(instance, ModelState);
                }
                else
                {
                    return BadRequest(ModelState);
                }

                UnitOfWork.Repository.Update(instance);
                UnitOfWork.Save();

                foreach (string prop in includeArray)
                {
                    instance = UnitOfWork.Repository.dbSet.Include(prop).SingleOrDefault(x => x.Id.Equals(instance.Id));
                }

                return instance;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        public IActionResult PutGen(Guid id, T instance)
        {
            if (id != instance.Id)
            {
                return BadRequest();
            }

            UnitOfWork.Repository.Update(instance);
            UnitOfWork.Save();

            return NoContent();
        }

        public ActionResult<T> PostGen(T instance)
        {
            UnitOfWork.Repository.Insert(instance);
            UnitOfWork.Save();

            return CreatedAtAction("GetMonster", new { id = instance.Id }, instance);
        }

        public ActionResult<T> DeleteGen(Guid id)
        {
            T instance = UnitOfWork.Repository.GetById(id);
            if (instance == null)
            {
                return NotFound();
            }

            UnitOfWork.Repository.Delete(instance);
            UnitOfWork.Save();

            return instance;
        }

        public ActionResult<List<string>> GetEnumGen(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return BadRequest();
            }

            try
            {
                return UnitOfWork.Repository.GetEnum(name).ToList();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
