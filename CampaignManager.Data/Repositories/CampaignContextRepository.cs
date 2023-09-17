using System;
using System.Linq;
using CampaignManager.Data.Contexts;
using CampaignManager.Data.Model;
using CampaignManager.Data.Model.Auth;
using CampaignManager.Data.Model.Games;

namespace CampaignManager.Data.Repositories
{
    public class CampaignContextRepository<TEntity> : GenericRepository<TEntity> where TEntity : class, IBase, ICampaignBase
    {
        public CampaignContextRepository(DDContext context) : base(context) { }

        public bool ValidateCampaignOwnership(Guid campaignId, Guid accountId)
            => dbSet.SingleOrDefault(x => x.Id == campaignId)?.OwnerId.Equals(accountId) ?? false;


        public virtual IEnumerable<TEntity> GetWithCampaign(Guid accountId, Guid campaignId, ListingFilterParameters<TEntity> parameters)
            => GetWithCampaignQuery(accountId, campaignId, parameters).ToList();


        protected virtual IQueryable<TEntity> GetWithCampaignQuery(Guid accountId, Guid campaignId, ListingFilterParameters<TEntity> parameters)
            => GetQuery(accountId, parameters).Where(x => x.CampaignId == campaignId);

    }
}


