using DDCatalogue.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDCatalogue.Model
{
    public class UnitOfWork<T> : IDisposable where T : class, IBase
    {
        private DDContext Context = new DDContext();
        private GenericRepository<T> Repo;


        public GenericRepository<T> Repository
        {
            get
            {
                return Repo ?? new GenericRepository<T>(Context);
            }
        }


        public void Save()
        {
            Context.SaveChanges();
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
