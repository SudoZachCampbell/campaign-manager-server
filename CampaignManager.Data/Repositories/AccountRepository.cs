using System;
using System.Linq;
using CampaignManager.Data.Contexts;
using CampaignManager.Data.Model.Auth;
using Microsoft.EntityFrameworkCore;

namespace CampaignManager.Data.Repositories
{
    public class AccountRepository
    {
        internal DDContext _context;
        public DbSet<Account> dbSet;

        public AccountRepository(DDContext context)
        {
            _context = context;
            dbSet = context.Set<Account>();
        }

        public Account GetUserByUsername(string username)
            => dbSet.FirstOrDefault(x => x.Username == username);

        public Account GetUserByEmail(string email)
            => dbSet.FirstOrDefault(x => x.Email == email);

        public Account GetById(Guid entityId) =>
            dbSet.SingleOrDefault(x => x.Id == entityId);

        public bool IsUsernameUnique(string username)
            => !dbSet.Any(x => x.Username == username);

        public bool IsEmailUnique(string email)
            => !dbSet.Any(x => x.Email == email);

        public void Insert(Account entity)
        {
            dbSet.Add(entity);
        }


        public void Delete(Guid entityId)
        {
            Account entityToDelete = GetById(entityId);
            Delete(entityToDelete);
        }

        public void Delete(Account entityToDelete)
        {
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        public void Update(Account entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            _context.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }
}


