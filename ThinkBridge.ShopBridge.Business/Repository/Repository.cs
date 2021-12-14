using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
//using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;

namespace ThinkBridge.ShopBridge.Business.Repository
{
    /// <summary>
    /// Generic CURD operation
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class Repository<T> : IRepository<T> where T : class
    {
        protected DbContext DbContext { get; set; }

        protected DbSet<T> DbSet { get; set; }

        public Repository(DbContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException("Null DbContext");
            }
            else
            {
                //Do nothing.
            }

            DbContext = dbContext;
            DbSet = DbContext.Set<T>();
        }

        public async Task<IQueryable<T>> GetAll()
        {
           return DbSet;
        }

        public virtual async Task<T> GetById(int id)
        {
            return DbSet.Find(id);
        }

        public virtual async Task<T> GetById(long id)
        {
            return DbSet.Find(id);
        }

        public virtual void Add(T entity)
        {
            EntityEntry dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State != EntityState.Detached)
            {
                dbEntityEntry.State = EntityState.Added;
            }
            else
            {
                DbSet.Add(entity);
            }
        }

        public virtual async void Update(T entity)
        {
            EntityEntry dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State == EntityState.Detached)
            {
                DbSet.Attach(entity);
            }
            dbEntityEntry.State = EntityState.Modified;

        }

        public virtual void Delete(T entity)
        {
            EntityEntry dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State != EntityState.Deleted)
            {
                dbEntityEntry.State = EntityState.Deleted;
            }
            else
            {
                DbSet.Attach(entity);
                DbSet.Remove(entity);
            }
        }

        public async virtual void Delete(int id)
        {
            var entity = await GetById(id);
            if (entity == null) return; // not found; assume already deleted.
            Delete(entity);
        }

    }
}