using CampaignManager.Data.Contexts;
using System;
using CampaignManager.Data.Model;
using CampaignManager.Data.Model.Auth;

namespace CampaignManager.Data.Repositories
{
    public class AccountUnitOfWork : UnitOfWork<Account>
    {
        public override AccountRepository Repository
        {
            get
            {
                return (AccountRepository)Repo ?? new AccountRepository(Context);
            }
        }


    }
}
