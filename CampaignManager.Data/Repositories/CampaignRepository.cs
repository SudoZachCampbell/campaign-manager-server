using System;
using System.Linq;
using CampaignManager.Data.Contexts;
using CampaignManager.Data.Model;
using CampaignManager.Data.Model.Auth;
using CampaignManager.Data.Model.Games;

namespace CampaignManager.Data.Repositories
{
    public class CampaignContextRepository<TEntity> : GenericRepository<TEntity> where TEntity : class, IOwned, ICampaignBase
    {
        public CampaignContextRepository(DDContext context) : base(context) { }

        public bool ValidateOwnership(Guid campaignId, Guid accountId)
            => dbSet.SingleOrDefault(x => x.Id == campaignId)?.OwnerId.Equals(accountId) ?? false;


        public virtual IEnumerable<TEntity> GetWithCampaign(Guid campaignId, ListingFilterParameters<TEntity> parameters)
        {
            IQueryable<TEntity> query = dbSet;

            query = Expand(query, parameters.ExpandProperties)
            .Where(x => x.CampaignId == campaignId)
                    .Skip((parameters.Page - 1) * parameters.PageSize)
                    .Take(parameters.PageSize);

            return query.ToList();
        }
    }
}


