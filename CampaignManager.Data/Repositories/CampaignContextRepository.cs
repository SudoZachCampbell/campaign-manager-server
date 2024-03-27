using System;
using System.Linq;
using CampaignManager.Data.Contexts;
using CampaignManager.Data.Model;
using CampaignManager.Data.Model.Auth;
using CampaignManager.Data.Model.Games;
using Microsoft.EntityFrameworkCore;

namespace CampaignManager.Data.Repositories
{
    public class CampaignContextRepository<TEntity> : GenericRepository<TEntity> where TEntity : class, IBase, ICampaignBase
    {
        public DbSet<Campaign> campaignDbSet;
        public CampaignContextRepository(DDContext context) : base(context)
        {
            campaignDbSet = context.Set<Campaign>();
        }

        public bool ValidateCampaignOwnership(Guid campaignId, Guid accountId)
        {
            var result = campaignDbSet.SingleOrDefault(x => x.Id == campaignId);
            return result?.OwnerId.Equals(accountId) ?? false;
        }


        public virtual IEnumerable<TEntity> GetWithCampaign(Guid accountId, Guid campaignId, ListingFilterParameters<TEntity> parameters)
            => GetWithCampaignQuery(accountId, campaignId, parameters).ToList();

        public virtual TEntity? GetSingleByCampaign(Guid accountId, Guid campaignId)
            => GetWithCampaignQuery(accountId, campaignId)?.FirstOrDefault();

        protected virtual IQueryable<TEntity>? GetWithCampaignQuery(Guid accountId, Guid campaignId, ListingFilterParameters<TEntity> parameters = null)
            => GetQuery(accountId, parameters).Where(x => x.CampaignId == campaignId);
    }
}


