using DDCatalogue.Contexts;
using System;
using DDCatalogue.Model;
using DDCatalogue.Model.Auth;

namespace DDCatalogue.Data
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
