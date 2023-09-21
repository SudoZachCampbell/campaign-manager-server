using CampaignManager.Data.Contexts;
using System;
using CampaignManager.Data.Model;

namespace CampaignManager.Data.Repositories
{
    public class AccountUnitOfWork : IDisposable
    {
        protected DDContext Context = new DDContext();
        protected AccountRepository Repo;


        public virtual AccountRepository Repository
        {
            get
            {
                return Repo ?? new AccountRepository(Context);
            }
        }


        public int Save()
        {
            return Context.SaveChanges();
        }

        private bool Disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.Disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
            this.Disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
