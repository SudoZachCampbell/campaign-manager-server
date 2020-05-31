using DDCatalogue.Model.Creatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDCatalogue.Model
{
    public class UnitOfWork: IDisposable
    {
        private DDContext Context = new DDContext();
        private GenericRepository<Monster> MonsterRepo;
        private GenericRepository<Npc> NpcRepo;

        public GenericRepository<Monster> MonsterRepository
        {
            get
            {
                return MonsterRepo ?? new GenericRepository<Monster>(Context);
            }
        }

        public GenericRepository<Npc> NpcRepository { 
            get
            {
                return NpcRepo ?? new GenericRepository<Npc>(Context);
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
