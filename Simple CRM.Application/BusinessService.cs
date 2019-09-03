using Simple_CRM.Domain;
using Simple_CRM.Infra.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Simple_CRM.Application
{
    public class BusinessService : IBusinessService
    {
        private IBusinessRepository _businessRepository;
        public BusinessService(IBusinessRepository businessRepository)
        {
            _businessRepository = businessRepository;
        }

        public bool Add(Business business)
        {
            if (!business.IsValid())
                return false;

            _businessRepository.Add(business);
            if (business.Id != 0)
                return true;
            else
                return false;
        }

        public IEnumerable<Business> GetAllActive()
        {
            var businessList = _businessRepository.GetAll();

            return businessList.Where(d => d.Status == true);
        }

        public Business GetOne(int id)
        {
            return _businessRepository.GetById(id);
        }

        public void Remove(Business business)
        {
            throw new NotImplementedException();
        }

        public void Update(Business business)
        {
            throw new NotImplementedException();
        }

        void IBusinessService.Add(Business business)
        {
            throw new NotImplementedException();
        }
    }
}
