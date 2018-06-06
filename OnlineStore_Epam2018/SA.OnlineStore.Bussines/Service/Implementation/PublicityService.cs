namespace SA.OnlineStore.Bussines.Components
{
    #region Usings
    using SA.OnlineStore.Bussines.Service;
    using SA.OnlineStore.Common.Entity;
    using SA.OnlineStore.DataAccess.Implements;
    using SA.OnlineStore.DataAccess.Service;
    using System.Collections.Generic;
    #endregion

    public class PublicityService :IPublicityService
    {
        private readonly IRepository<Publicity> _publicityRepository;

        public PublicityService(IRepository<Publicity> publicityRepository)
        {
            _publicityRepository = publicityRepository;
        }

        //public PublicityModel GetPublicity()
        //{
        //    PublicityModel publicity = _publicityRepository.GetPublicity();
        //    return publicity;
        //}       
        //public IEnumerable<Publicity> GetDefaultList()
        //{
        //    IEnumerable<Publicity> resultList = _publicityRepository.GetDefaultList();
        //    return resultList;
        //}
        public IEnumerable<Publicity> GetPublicityList()
        {
            IEnumerable<Publicity> resultList = _publicityRepository.GetAll();
            return resultList;
        }
    }
}