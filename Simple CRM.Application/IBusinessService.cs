using Simple_CRM.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Simple_CRM.Application
{
    public interface IBusinessService
    {
        Business GetOne(int id);
        IEnumerable<Business> GetAllActive();
        void Add(Business business);
        void Update(Business business);
        void Remove(Business business);        
    }
}
