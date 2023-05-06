using System;
using System.Linq;
using DDCatalogue.Contexts;
using DDCatalogue.Model.Auth;

namespace DDCatalogue.Data
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


