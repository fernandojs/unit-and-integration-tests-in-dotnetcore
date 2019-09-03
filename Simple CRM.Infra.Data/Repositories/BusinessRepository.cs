using Microsoft.EntityFrameworkCore;
using Simple_CRM.Domain;
using Simple_CRM.Infra.Data.Context;
using Simple_CRM.Infra.Data.Repositories.Interfaces;
using System;
using System.Linq;

namespace Simple_CRM.Infra.Data.Repositories
{ 
    public class BusinessRepository : GenericRepository<Business>, IBusinessRepository
    {
        public BusinessRepository(SimpleCRMDbContext dbContext) : base(dbContext)
        {
        }

        public override IQueryable<Business> GetAll()
        {
            IQueryable<Business> query = _entities.Set<Business>();
            return query;
        }


        public Business GetById(int id)
        {
            return _entities.Set<Business>().Find(id);
        }
  

        public void Update(Business Business)
        {
            var toUpdate = GetSingle(Business.Id);
            toUpdate.Name = Business.Name;            
            Save();
        }

    }
}
