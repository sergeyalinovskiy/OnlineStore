namespace SA.OnlineStore.Bussines.Components
{
    #region Usings
        using SA.OnlineStore.Bussines.Service;
        using SA.OnlineStore.Common.Entity;
        using SA.OnlineStore.DataAccess.Implements;
        using SA.OnlineStore.DataAccess.Repositorys;
        using System.Collections.Generic;
    #endregion

    public class PublicityService :IPublicityService
    {
        private readonly IRepository<Publicity> _publicityRepository;

        public PublicityService(IRepository<Publicity> publicityRepository)
        {
            _publicityRepository = publicityRepository;
        }
  
        public IEnumerable<Publicity> GetPublicityList()
        {
            IEnumerable<Publicity> resultList = _publicityRepository.GetAll();
            return resultList;
        }
    }
}