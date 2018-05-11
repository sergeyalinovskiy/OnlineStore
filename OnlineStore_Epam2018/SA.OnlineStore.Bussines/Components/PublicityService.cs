
using SA.OnlineStore.Bussines.Service;
using SA.OnlineStore.Common.Entity;
using SA.OnlineStore.DataAccess.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.OnlineStore.Bussines.Components
{
    public class PublicityService :IPublicityService
    {
        private readonly IPublicityRepository _publicityRepository;

        public PublicityService(IPublicityRepository publicityRepository)
        {
            _publicityRepository = publicityRepository;
        }

        public PublicityModel GetPublicity()
        {
            PublicityModel publicity = _publicityRepository.GetPublicity();
            return publicity;
        }       

        public IEnumerable<PublicityModel> GetPublicityList()
        {
            IEnumerable<PublicityModel> resultList = _publicityRepository.GetPublicityList();
            return resultList;
        }

    }
}
