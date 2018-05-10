using SA.OnlineStore.DataAccess.Entity;
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
    public class PublicityService : IPublicityRepository
    {
        private ChannelFactory<FirstWebServiceReference.IFirstWebService> _channel = new 
            ChannelFactory<FirstWebServiceReference.IFirstWebService>(new BasicHttpBinding(), new EndpointAddress("http://localhost:51702/FirstWebService.svc"));

        private FirstWebServiceReference.IFirstWebService _service;

        public PublicityService()
        {
            _service = _channel.CreateChannel();
        }

        public PublicityWcf GetPublicity()
        {
            PublicityWcf publicity = ConvertToDataAccessModel(_service.GetPublicity(1));
            return publicity;
        }

        public IEnumerable<PublicityWcf> GetPublicityList()
        {
            IEnumerable<PublicityWcf> publicityList = ConvertToPublicityWcfList(_service.GetPublicityList());
            return publicityList;
        }


        public IEnumerable<PublicityWcf> ConvertToPublicityWcfList(IEnumerable<Publicity> listModel)
        {
            List<PublicityWcf> resultList = new List<PublicityWcf>();

            foreach(Publicity item in listModel)
            {
                resultList.Add(ConvertToDataAccessModel(item));
            }
            return resultList;
        }

        public PublicityWcf ConvertToDataAccessModel(Publicity model)
        {
            return new PublicityWcf
            {
                Id=model.Id,
                Name = model.Name,
                Text = model.Text
            };
        }
    }
}
