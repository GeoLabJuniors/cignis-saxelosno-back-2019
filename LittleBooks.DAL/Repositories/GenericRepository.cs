using LittleBooks.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleBooks.DAL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected DbContext Context;
        public GenericRepository(DbContext context)
        {
            this.Context = context;
        }
        public void Add(T obj)
        {
            Context.Set<T>().Add(obj);
        }

        public T Get(int id)
        {
            var data = Context.Set<T>().Find(id);
            return data;
        }

        public IQueryable<T> GetAll()
        {
            var data = Context.Set<T>();
            return data;
        }

        public void Save()
        {
            Context.SaveChanges();
        }
    }
}
