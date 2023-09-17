using System.Globalization;
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

        public virtual IEnumerable<TEntity> Get(Guid accountId, ListingFilterParameters<TEntity> parameters)
            => GetQuery(accountId, parameters).ToList();



        protected virtual IQueryable<TEntity> GetQuery(Guid accountId, ListingFilterParameters<TEntity> parameters)
        {
            IQueryable<TEntity> query = dbSet.Where(entity => entity.OwnerId == accountId);

            query = Expand(query, parameters.ExpandProperties)
                    .Skip((parameters.Page - 1) * parameters.PageSize)
                    .Take(parameters.PageSize);

            return query;
        }

        public virtual TEntity GetById(Guid accountId, Guid entityId) =>
            dbSet.Where(entity => entity.OwnerId == accountId).SingleOrDefault(x => x.Id == entityId);


        public virtual TEntity GetById(Guid accountId, Guid entityId, FilterParameters<TEntity> parameters)
        {
            IQueryable<TEntity> query = dbSet.Where(entity => entity.OwnerId == accountId);

            query = Expand(query, parameters.ExpandProperties);
            return query.SingleOrDefault(entity => entity.Id == entityId);
        }

        public virtual void Insert(Guid accountId, TEntity entity)
        {
            dbSet.Add(entity);
        }


        public virtual void Delete(Guid accountId, Guid entityId)
        {
            TEntity entityToDelete = GetById(accountId, entityId);
            Delete(accountId, entityToDelete);
        }

        public virtual void Delete(Guid accountId, TEntity entityToDelete)
        {
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        public virtual void Update(Guid accountId, TEntity entityToUpdate)
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


