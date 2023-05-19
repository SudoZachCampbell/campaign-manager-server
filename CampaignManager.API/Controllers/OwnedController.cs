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
    public class OwnedController<T> : GenericController<T> where T : class, IOwned
    {
        protected virtual OwnedUnitOfWork<T> UnitOfWork { get; } = new();
        protected readonly IConfiguration Configuration;

        public OwnedController(IConfiguration configuration) : base(configuration)
        {
        }

        protected ActionResult<List<T>> GetGenOwned(Account user, ListingFilterParameters<T> parameters)
        {
            Response.Headers.Add("X-Pagination",
                JsonSerializer.Serialize(parameters, options: new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
                }
            ));
            return UnitOfWork.Repository.GetOwned(user, parameters).AsQueryable()
                .Filter(parameters.Filter)
                .OrderBy(parameters.OrderBy ?? "name")
                .IncludeProperties<T>(parameters.IncludeProperties)
                .ToDynamicList<T>();
        }
    }
}
