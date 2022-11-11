using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DDCatalogue.Model
{
    public class GenericRepository<TEntity> where TEntity : class, IBase
    {
        internal DDContext _context;
        internal DbSet<TEntity> dbSet;
        public GenericRepository(DDContext context)
        {
            _context = context;
            dbSet = context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string[] includeProperties = null)
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            query = Includes(query, includeProperties);

            return orderBy != null ? orderBy(query).ToList() : query.ToList();
        }

        public virtual TEntity GetById(Guid id, string[] includeProperties = null)
        {
            IQueryable<TEntity> query = dbSet;

            if (includeProperties == null)
            {
                return dbSet.Find(id);
            }
            else
            {
                query = Includes(query, includeProperties);
                return query.SingleOrDefault(x => x.Id == id);
            }
        }

        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            _context.Entry(entityToUpdate).State = EntityState.Modified;
        }
        public IEnumerable<string> GetEnum(string name)
        {
            return Enum.GetNames(Type.GetType($"{typeof(TEntity).Namespace}.{name}")).ToList();
        }

        private IQueryable<TEntity> Includes(IQueryable<TEntity> query, string[] includeProperties = null)
        {
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }
            return query;
        }

    }
}
