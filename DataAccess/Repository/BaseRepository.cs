using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace DataAccess.Repository
{
    public abstract class BaseRepository<T> where T : BaseEntity
    {
        protected TaskManagerDb context;
        protected DbSet<T> dbSet;

        protected BaseRepository(TaskManagerDb context)
        {
            this.context = context;
            dbSet = context.Set<T>();
        }

        public List<T> GetAll(Func<T, bool> where = null)
        {
            if(where != null)
            {
                return dbSet.Where(where).ToList();
            }
            return dbSet.ToList();
        }

        public void Insert(T item)
        {
            dbSet.Add(item);
            context.SaveChanges();
        }

        public void Update(T item)
        {
            dbSet.AddOrUpdate(i => i.Id, item);
            context.SaveChanges();

        }

        public virtual T GetById(int id)
        {
            return dbSet.Find(id);
        }

        public virtual void Delete(T item)
        {
            T itemToDelete = dbSet.Find(item.Id);
            dbSet.Remove(itemToDelete);
            context.SaveChanges();
        }

        public void Save(T item)
        {
            if(item.Id > 0)
            {
                Update(item);
            }
            else
            {
                Insert(item);
            }

        }


    }
}