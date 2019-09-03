using System;
using System.Linq;
using System.Linq.Expressions;

namespace Simple_CRM.Infra.Data.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> GetAll();        
        T GetSingle(int Id);
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        T Add(T entity);
        void Delete(T entity);
        void Save();
    }
}
