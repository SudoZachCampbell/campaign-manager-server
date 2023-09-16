using CampaignManager.Data.Model;
using CampaignManager.Data.Model.Games;

namespace CampaignManager.Data.Repositories
{
    public class CampaignContextUnitOfWork<T> : UnitOfWork<T> where T : class, IOwned, ICampaignBase
    {
        public override CampaignContextRepository<T> Repository
        {
            get
            {
                return (CampaignContextRepository<T>)Repo ?? new CampaignContextRepository<T>(Context);
            }
        }


    }
}
