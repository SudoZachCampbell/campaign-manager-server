﻿using System.Globalization;
using Microsoft.EntityFrameworkCore;
using CampaignManager.Data.Contexts;
using CampaignManager.Data.Model;
using CampaignManager.Data.Model.Auth;

namespace CampaignManager.Data.Repositories
{
    public class GenericRepository<TEntity> where TEntity : class, IBase
    {
        internal DDContext _context;
        public DbSet<TEntity> dbSet;
        public GenericRepository(DDContext context)
        {
            _context = context;
            dbSet = context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> Get(ListingFilterParameters<TEntity> parameters)
        {
            IQueryable<TEntity> query = dbSet;

            query = Expand(query, parameters.ExpandProperties)
                    .Skip((parameters.Page - 1) * parameters.PageSize)
                    .Take(parameters.PageSize);

            return query.ToList();
        }

        public virtual TEntity GetById(Guid id) => dbSet.SingleOrDefault(x => x.Id == id);



        public virtual TEntity GetById(Guid id, FilterParameters<TEntity> parameters)
        {
            IQueryable<TEntity> query = dbSet;

            query = Expand(query, parameters.ExpandProperties);
            return query.SingleOrDefault(x => x.Id == id);
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

        // private IQueryable<TEntity> Include(IQueryable<TEntity> query, string[] includeProperties = null)
        // {
        //     if (includeProperties != null)
        //     {
        //         // var parameter = Expression.Parameter(typeof(TEntity), "e");
        //         // var bindings = includeProperties
        //         //     .Select(name => Expression.PropertyOrField(parameter, CultureInfo.InvariantCulture.TextInfo.ToTitleCase(name).Replace("_", "")))
        //         //     .Select(member => Expression.Bind(member.Member, member));
        //         // var body = Expression.MemberInit(Expression.New(typeof(TEntity)), bindings);
        //         // var selector = Expression.Lambda<Func<TEntity, TEntity>>(body, parameter);
        //         return 

        //     }
        //     else
        //         return query;
        // }

        protected IQueryable<TEntity> Expand(IQueryable<TEntity> query, string[] expandProperties = null)
        {
            if (expandProperties != null)
            {
                foreach (var expandProperty in expandProperties)
                {
                    query = query.Include(CultureInfo.InvariantCulture.TextInfo.ToTitleCase(expandProperty));
                }
            }
            return query;
        }

    }
}


