namespace SA.OnlineStore.Bussines.Components
{
    #region Usings
    using SA.OnlineStore.Bussines.Service;
    using SA.OnlineStore.Common.Entity;
    using SA.OnlineStore.DataAccess.Service;
    using System.Collections.Generic;
    #endregion

    public class PublicityService :IPublicityService
    {
        private readonly IPublicityRepository _publicityRepository;

        public PublicityService(IPublicityRepository publicityRepository)
        {
            _publicityRepository = publicityRepository;
        }

        //public PublicityModel GetPublicity()
        //{
        //    PublicityModel publicity = _publicityRepository.GetPublicity();
        //    return publicity;
        //}       
        public IEnumerable<PublicityModel> GetDefaultList()
        {
            IEnumerable<PublicityModel> resultList = _publicityRepository.GetDefaultList();
            return resultList;
        }
        public IEnumerable<PublicityModel> GetPublicityList()
        {
            IEnumerable<PublicityModel> resultList = _publicityRepository.GetPublicityList();
            return resultList;
        }
    }
}