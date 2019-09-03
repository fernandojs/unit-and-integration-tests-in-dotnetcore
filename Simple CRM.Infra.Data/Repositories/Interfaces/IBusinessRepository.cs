using Simple_CRM.Domain;

namespace Simple_CRM.Infra.Data.Repositories.Interfaces
{
    public interface IBusinessRepository : IGenericRepository<Business>
    {
        Business GetById(int id);        
        void Update(Business business);
    }
}
