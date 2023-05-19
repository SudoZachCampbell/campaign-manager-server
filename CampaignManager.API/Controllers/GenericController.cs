using CampaignManager.Data.Model;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Linq.Dynamic.Core;
using Microsoft.Extensions.Configuration;
using CampaignManager.Data.Repositories;
using CampaignManager.Data.Model.Auth;

namespace CampaignManager.API.Controllers
{
    public class GenericController<T> : ControllerBase where T : class, IBase
    {
        protected virtual UnitOfWork<T> UnitOfWork { get; } = new();
        protected readonly IConfiguration Configuration;

        public GenericController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        [HttpGet("[action]")]
        protected ActionResult<string> Status()
        {
            return "Running";
        }

        protected ActionResult<List<T>> GetGen(ListingFilterParameters<T> parameters)
        {
            Response.Headers.Add("X-Pagination",
                JsonSerializer.Serialize(parameters, options: new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
                }
            ));
            return UnitOfWork.Repository.Get(parameters).AsQueryable()
                .Filter(parameters.Filter)
                .OrderBy(parameters.OrderBy ?? "name")
                .IncludeProperties<T>(parameters.IncludeProperties)
                .ToDynamicList<T>();
        }

        protected ActionResult<T> GetGen(Guid id, FilterParameters<T> parameters)
        {
            T instance = UnitOfWork.Repository.GetById(id, parameters);

            if (instance == null) return NotFound();

            return instance;
        }

        protected ActionResult<T> PatchGen(Guid id, [FromBody] JsonPatchDocument<T> patchDoc, FilterParameters<T> parameters)
        {
            if (patchDoc != null)
            {
                T instance = UnitOfWork.Repository.GetById(id, parameters);

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

                foreach (string prop in parameters.ExpandProperties)
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

        protected CreatedResult PostGen(T instance)
        {
            UnitOfWork.Repository.Insert(instance);
            int result = UnitOfWork.Save();

            if (result > 0)
            {
                return Created($"accounts/{instance.Id}", instance.Id);
            }
            else
            {
                throw new Exception($"Error creating {instance.GetType().Name}");
            }
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

            return NoContent();
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
