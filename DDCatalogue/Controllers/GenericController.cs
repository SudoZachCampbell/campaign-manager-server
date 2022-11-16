using DDCatalogue.Model;
using DDCatalogue.Model.Creatures;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DDCatalogue.Controllers
{
    public class GenericController<T> : ControllerBase where T : class, IBase
    {
        protected readonly UnitOfWork<T> UnitOfWork = new UnitOfWork<T>();

        [HttpGet("[action]")]
        protected ActionResult<string> Status()
        {
            return "Running";
        }

        protected ActionResult<List<dynamic>> GetGen([FromQuery] ListingParameters<T> parameters)
        {
            Response.Headers.Add("X-Pagination",
                JsonSerializer.Serialize(parameters, options: new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
                }
            ));
            try
            {
                return UnitOfWork.Repository.Get(parameters).AsQueryable().IncludeProperties(parameters.IncludeProperties);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        protected ActionResult<T> GetGen(Guid id, [FromQuery] string include)
        {
            T instance = UnitOfWork.Repository.GetById(id, includeProperties: include?.Split(','));

            if (instance == null) return NotFound();

            return instance;
        }

        protected ActionResult<T> PatchGen(Guid id, [FromBody] JsonPatchDocument<T> patchDoc, [FromQuery] string include)
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

        protected IActionResult PutGen(Guid id, T instance)
        {
            if (id != instance.Id)
            {
                return BadRequest();
            }

            UnitOfWork.Repository.Update(instance);
            UnitOfWork.Save();

            return NoContent();
        }

        protected ActionResult<T> PostGen(T instance)
        {
            UnitOfWork.Repository.Insert(instance);
            UnitOfWork.Save();

            return CreatedAtAction("GetMonster", new { id = instance.Id }, instance);
        }

        protected ActionResult<T> DeleteGen(Guid id)
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

        protected ActionResult<List<string>> GetEnumGen(string name)
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
