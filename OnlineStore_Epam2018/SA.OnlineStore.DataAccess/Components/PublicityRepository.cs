using SA.OnlineStore.Common.Entity;
using SA.OnlineStore.DataAccess.FirstWebServiceReference;
using SA.OnlineStore.DataAccess.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SA.OnlineStore.DataAccess.Components
{
    public class PublicityRepository : IPublicityRepository
    {
        private ChannelFactory<FirstWebServiceReference.IFirstWebService> _channel = new 
            ChannelFactory<FirstWebServiceReference.IFirstWebService>(new BasicHttpBinding(), new EndpointAddress("http://localhost:51702/FirstWebService.svc"));

        private FirstWebServiceReference.IFirstWebService _service;

        public PublicityRepository()
        {
            _service = _channel.CreateChannel();
        }

        public PublicityModel GetPublicity()
        {
            PublicityModel publicity = ConvertToDataAccessModel(_service.GetPublicity(1));
            return publicity;
        }

        public IEnumerable<PublicityModel> GetPublicityList()
        {
            IEnumerable<PublicityModel> publicityList = ConvertToPublicityWcfList(_service.GetPublicityList());
            return publicityList;
        }

        public IEnumerable<PublicityModel> ConvertToPublicityWcfList(IEnumerable<Publicity> listModel)
        {
            List<PublicityModel> resultList = new List<PublicityModel>();

            foreach(Publicity item in listModel)
            {
                resultList.Add(ConvertToDataAccessModel(item));
            }
            return resultList;
        }

        public PublicityModel ConvertToDataAccessModel(Publicity model)
        {
            return new PublicityModel
            {
                Id=model.Id,
                Name = model.Name,
                Text = model.Text
            };
        }
    }
}
