using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Simple_CRM.Infra.Data.Context;
using Simple_CRM.Infra.Data.Repositories.Interfaces;

namespace Simple_CRM.Infra.Data.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected SimpleCRMDbContext _entities;
        protected DbSet<T> _dbSet;

        public GenericRepository(SimpleCRMDbContext context)
        {
            _entities = context;
            _dbSet = context.Set<T>();
        }

        public virtual IQueryable<T> GetAll()
        {

            IQueryable<T> query = _entities.Set<T>();
            return query;
        }

        public IQueryable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {

            IQueryable<T> query = _entities.Set<T>().Where(predicate);
            return query;
        }

        public virtual T Add(T entity)
        {
            _entities.Set<T>().Add(entity);
            Save();
            return entity;
        }

        public virtual void Delete(T entity)
        {
            _entities.Set<T>().Remove(entity);
            Save();
        }

        public virtual void Save()
        {
            _entities.SaveChanges();
        }

        public T GetSingle(int Id)
        {
            return _entities.Set<T>().Find(Id);
        }

    }
}
