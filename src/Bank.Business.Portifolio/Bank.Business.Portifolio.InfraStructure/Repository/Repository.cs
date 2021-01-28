using Bank.Business.Portifolio.Domain.Interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace Bank.Business.Portifolio.InfraStructure.Repository
{
    public class Repository<TEntity> : IDisposable, IRepository<TEntity> where TEntity : class
    {
        protected Context.Context Db = new Context.Context();

        public void Add(TEntity obj)
        {
            Db.Set<TEntity>().Add(obj);
            Db.SaveChanges();
        }
        public TEntity GetById(int id)
        {
            return Db.Set<TEntity>().Find(id);
        }
        public IEnumerable<TEntity> GetAll()
        {
            return Db.Set<TEntity>();
        }
        public void Update(TEntity obj)
        {
            Db.Entry(obj).State = EntityState.Modified;
            Db.SaveChanges();
        }
        public void Remove(TEntity obj)
        {
            Db.Set<TEntity>().Remove(obj);
            Db.SaveChanges();
        }
        public void Dispose()
        {
            //GC.Collect();
        }
    }
}
