using CampaignManager.Data.Model;

namespace CampaignManager.Data.Repositories
{
    public class OwnedUnitOfWork<T> : UnitOfWork<T> where T : class, IOwned
    {
        public override OwnedRepository<T> Repository
        {
            get
            {
                return (OwnedRepository<T>)Repo ?? new OwnedRepository<T>(Context);
            }
        }


    }
}
