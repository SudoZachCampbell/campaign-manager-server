using Microsoft.EntityFrameworkCore;
using CampaignManager.Data.Contexts;
using CampaignManager.Data.Model;
using CampaignManager.Data.Model.Auth;

namespace CampaignManager.Data.Repositories
{
    public class OwnedRepository<TEntity> : GenericRepository<TEntity> where TEntity : class, IOwned
    {
        internal DDContext _context;
        public OwnedRepository(DDContext context) : base(context) { }

        public virtual IEnumerable<TEntity> GetOwned(Account user, ListingFilterParameters<TEntity> parameters)
        {
            IQueryable<TEntity> query = dbSet.Where(item => item.OwnerId == user.Id);

            query = Expand(query, parameters.ExpandProperties)
                    .Skip((parameters.Page - 1) * parameters.PageSize)
                    .Take(parameters.PageSize);

            return query.ToList();
        }
    }
}


