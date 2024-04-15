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
using Microsoft.Identity.Client;
using AutoMapper;

namespace CampaignManager.API.Controllers
{
    public class GenericController<T> : ControllerBase where T : class, IBase
    {
        protected virtual UnitOfWork<T> UnitOfWork { get; } = new();
        protected readonly IConfiguration Configuration;
        protected readonly IMapper Mapper;

        public GenericController(IConfiguration configuration, IMapper mapper)
        {
            Configuration = configuration;
            Mapper = mapper;
        }

        [HttpGet("[action]")]
        protected ActionResult<string> Status()
        {
            return "Running";
        }

        protected virtual List<T> GetGen(Guid accountId, ListingFilterParameters<T> parameters)
            => GetGenQuery(accountId, parameters).ToDynamicList<T>();


        protected virtual IQueryable<T> GetGenQuery(Guid accountId, ListingFilterParameters<T> parameters)
        {
            Response.Headers.Add("X-Pagination",
                JsonSerializer.Serialize(parameters, options: new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
                }
            ));
            return UnitOfWork.Repository.Get(accountId, parameters).AsQueryable()
                .Filter(parameters.Filter)
                .OrderBy(parameters.OrderBy ?? "name")
                .IncludeProperties<T>(parameters.IncludeProperties);
        }

        protected T GetGen(Guid accountId, Guid id, FilterParameters<T> parameters)
        {
            T instance = UnitOfWork.Repository.GetById(accountId, id, parameters);

            return instance;
        }

        protected ActionResult<T> PatchGen(Guid accountId, Guid id, [FromBody] JsonPatchDocument<T> patchDoc, FilterParameters<T> parameters)
        {
            if (patchDoc != null)
            {
                T instance = UnitOfWork.Repository.GetById(accountId, id, parameters);

                if (instance != null)
                {
                    patchDoc.ApplyTo(instance, ModelState);
                }
                else
                {
                    return BadRequest(ModelState);
                }

                UnitOfWork.Repository.Update(accountId, instance);
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

        protected IActionResult PutGen(Guid accountId, Guid id, T instance)
        {
            if (id != instance.Id)
            {
                return BadRequest();
            }

            UnitOfWork.Repository.Update(accountId, instance);
            UnitOfWork.Save();

            return NoContent();
        }

        protected CreatedResult PostGen(Guid accountId, T instance)
        {
            instance.OwnerId = accountId;
            UnitOfWork.Repository.Insert(accountId, instance);
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

        protected ActionResult DeleteGen(Guid accountId, Guid id)
        {
            T instance = UnitOfWork.Repository.GetById(accountId, id);
            if (instance == null)
            {
                return NotFound();
            }

            UnitOfWork.Repository.Delete(accountId, instance);
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
