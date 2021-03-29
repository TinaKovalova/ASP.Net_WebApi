using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public abstract class GenericRepository<T> : IRepository<T> where T : class
    {
        DbContext context;
        DbSet<T> table;
        public GenericRepository(DbContext context)
        {
            this.context = context;
            table = this.context.Set<T>();
        }
        public void CreateOrUpdate(T entity) => table.AddOrUpdate(entity);

        public T Get(int id) => table.Find(id);

        public IEnumerable<T> GetAll() => table;

        public void Delete(T entity) => table.Remove(entity);

        public void Save() => context.SaveChanges();
    }
}
