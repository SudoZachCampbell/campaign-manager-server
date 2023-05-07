using CampaignManager.Data.Contexts;
using System;
using CampaignManager.Data.Model;

namespace CampaignManager.Data.Repositories
{
    public class UnitOfWork<T> : IDisposable where T : class, IBase
    {
        protected DDContext Context = new DDContext();
        protected GenericRepository<T> Repo;


        public virtual GenericRepository<T> Repository
        {
            get
            {
                return Repo ?? new GenericRepository<T>(Context);
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
