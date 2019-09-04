using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleBooks.DAL.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        void Add(T obj);
        void Save();
        T Get(int id);
        IQueryable<T> GetAll();
    }
}
