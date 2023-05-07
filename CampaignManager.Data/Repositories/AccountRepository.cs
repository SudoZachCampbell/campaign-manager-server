using System;
using System.Linq;
using CampaignManager.Data.Contexts;
using CampaignManager.Data.Model.Auth;

namespace CampaignManager.Data.Repositories
{
    public class AccountRepository : GenericRepository<Account>
    {
        public AccountRepository(DDContext context) : base(context) { }

        public Account GetUserByUsername(string username)
            => dbSet.FirstOrDefault(x => x.Username == username);



        public Account GetUserByEmail(string email)
            => dbSet.FirstOrDefault(x => x.Email == email);
    }
}


