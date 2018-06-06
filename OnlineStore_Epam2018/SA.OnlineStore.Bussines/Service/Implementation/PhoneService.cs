using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SA.OnlineStore.Common.Entity;
using SA.OnlineStore.DataAccess.Implements;

namespace SA.OnlineStore.Bussines.Service.Implementation
{
    public class PhoneService : IPhoneService
    {
        private readonly IRepository<Phone> _phoneRepository;
        public PhoneService(IRepository<Phone> phoneRepository)
        {
            _phoneRepository = phoneRepository;
        }

        public IEnumerable<Phone> GetPhnesByUserId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Phone> GetPhoneList()
        {
            return _phoneRepository.GetAll();
        }
    }
}
