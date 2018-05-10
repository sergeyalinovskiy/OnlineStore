using SA.OnlineStore.Bussines.Entity;
using SA.OnlineStore.Bussines.Service;
using SA.OnlineStore.DataAccess.Entity;
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

        public Publicity GetPublicity()
        {
            Publicity publicity = ConvetToBussines(_publicityRepository.GetPublicity());
            return publicity;
        }       

        public IEnumerable<Publicity> GetPublicityList()
        {
            IEnumerable<Publicity> resultList = ConvertToPublicityList(_publicityRepository.GetPublicityList());
            return resultList;
        }


        public IEnumerable<Publicity> ConvertToPublicityList(IEnumerable<PublicityWcf> listModel)
        {
            List<Publicity> resultList = new List<Publicity>();

            foreach (PublicityWcf item in listModel)
            {
                resultList.Add(ConvetToBussines(item));
            }
            return resultList;
        }


        public Publicity ConvetToBussines(PublicityWcf model)
        {
            return new Publicity
            {
                Id = model.Id,
                Name = model.Name,
                Text = model.Text
            };
        }
    }
}
