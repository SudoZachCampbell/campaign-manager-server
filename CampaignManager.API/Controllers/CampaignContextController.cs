using CampaignManager.Data.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using Microsoft.Extensions.Configuration;
using CampaignManager.Data.Repositories;
using Microsoft.AspNetCore.JsonPatch;

namespace CampaignManager.API.Controllers
{
    public class CampaignContextController<T> : GenericController<T> where T : class, IBase, ICampaignBase
    {
        protected virtual CampaignContextUnitOfWork<T> CampaignContextUnitOfWork { get; } = new();

        public CampaignContextController(IConfiguration configuration) : base(configuration) { }

        protected bool ValidateCampaignOwnership(Guid accountId, Guid campaignId) =>
            CampaignContextUnitOfWork.Repository.ValidateCampaignOwnership(campaignId, accountId);

        protected ActionResult<IEnumerable<T>> GetGen(Guid accountId, Guid campaignId, ListingFilterParameters<T> parameters) =>
            ValidateCampaignOwnership(accountId, campaignId)
                ? Ok(CampaignContextUnitOfWork.Repository.GetWithCampaign(accountId, campaignId, parameters))
                : throw new AccessViolationException("You do not have access to this campaign");



        protected ActionResult<T> GetGenById(Guid accountId, Guid campaignId, Guid entityId, FilterParameters<T> parameters) =>
            ValidateCampaignOwnership(accountId, campaignId)
                ? Ok(CampaignContextUnitOfWork.Repository.GetById(accountId, entityId, parameters))
                : throw new AccessViolationException("You do not have access to this campaign");


        protected ActionResult<T> PatchGen(Guid accountId, Guid campaignId, Guid entityId, JsonPatchDocument<T> patchDoc, FilterParameters<T> parameters) =>
            ValidateCampaignOwnership(accountId, campaignId)
                ? PatchGen(accountId, entityId, patchDoc, parameters)
                : throw new AccessViolationException("You do not have access to this campaign");


        protected IActionResult PutGen(Guid accountId, Guid campaignId, Guid entityId, T entity) =>
            ValidateCampaignOwnership(accountId, campaignId)
                ? PutGen(accountId, entityId, entity)
                : throw new AccessViolationException("You do not have access to this campaign");


        protected ActionResult<Guid> PostGen(Guid accountId, Guid campaignId, T entity) =>
            ValidateCampaignOwnership(accountId, campaignId)
                ? PostGen(accountId, entity)
                : throw new AccessViolationException("You do not have access to this campaign");

        protected ActionResult DeleteGen(Guid accountId, Guid campaignId, Guid entityId) =>
            ValidateCampaignOwnership(accountId, campaignId)
                ? DeleteGen(accountId, entityId)
                : throw new AccessViolationException("You do not have access to this campaign");

    }
}
