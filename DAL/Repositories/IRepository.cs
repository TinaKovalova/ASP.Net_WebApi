using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IRepository<T>where T:class
    {
        void CreateOrUpdate(T entity);
        IEnumerable<T> GetAll();
        T Get(int id);
        void Delete(T entity);
        void Save();

    }
}
