using CampaignManager.Data.Model;
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
using CampaignManager.Data.Model.Games;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace CampaignManager.API.Controllers
{
    public class CampaignContextController<T> : GenericController<T> where T : class, IOwned, ICampaignBase
    {
        protected virtual CampaignContextUnitOfWork<T> CampaignContextUnitOfWork { get; } = new();

        public CampaignContextController(IConfiguration configuration) : base(configuration) { }

        protected bool ValidateOwnership(Guid campaignId, Account currentUser) =>
            CampaignContextUnitOfWork.Repository.ValidateOwnership(campaignId, currentUser.Id);

        protected ActionResult<List<T>> GetGen(Guid campaignId, ListingFilterParameters<T> parameters)
        {
            return CampaignContextUnitOfWork.Repository.GetWithCampaign(campaignId, parameters).ToList();
        }
    }
}
