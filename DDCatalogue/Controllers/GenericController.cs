using DDCatalogue.Model;
using DDCatalogue.Model.Creatures;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;


namespace DDCatalogue.Controllers
{
    public class GenericController<T> : ControllerBase where T : class, IModel
    {
        protected readonly UnitOfWork<T> UnitOfWork = new UnitOfWork<T>();

        public ActionResult<List<T>> GetGen([FromQuery] string include)
        {
            return UnitOfWork.Repository.Get(includeProperties: include?.Split(',')).ToList();
        }

        public ActionResult<T> GetGen(int id, [FromQuery] string include)
        {
            T instance = UnitOfWork.Repository.GetById(id, includeProperties: include?.Split(','));

            if (instance == null) return NotFound();

            return instance;
        }

        public ActionResult<T> PatchGen(int id, [FromBody] JsonPatchDocument<T> patchDoc, [FromQuery] string include)
        {
            if (patchDoc != null)
            {
                T instance = UnitOfWork.Repository.GetById(id, includeProperties: include?.Split(','));

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

                return instance;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        public IActionResult PutGen(int id, T instance)
        {
            if (id != instance.Id)
            {
                return BadRequest();
            }

            UnitOfWork.Repository.Update(instance);
            UnitOfWork.Save();

            return NoContent();
        }

        public ActionResult<Monster> PostGen(T instance)
        {
            UnitOfWork.Repository.Insert(instance);
            UnitOfWork.Save();

            return CreatedAtAction("GetMonster", new { id = instance.Id }, instance);
        }

        public ActionResult<T> DeleteGen(int id)
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
