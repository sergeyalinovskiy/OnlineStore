namespace SA.OnlineStore.Bussines.Service.Implementation
{
    #region Usings
        using System;
        using System.Collections.Generic;
        using SA.OnlineStore.Common.Entity;
        using SA.OnlineStore.DataAccess.Implements;
    #endregion
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
