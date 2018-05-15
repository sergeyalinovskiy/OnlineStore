namespace SA.OnlineStore.DataAccess.Components
{
    #region Usings
    using SA.OnlineStore.Common.Entity;
    using SA.OnlineStore.DataAccess.NewServiceReference;
    using SA.OnlineStore.DataAccess.Service;
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.IO;
    using System.ServiceModel;
    using System.ServiceModel.Configuration;
    using System.Web.UI;
    #endregion

    public class PublicityRepository : IPublicityRepository
    {
        //private ChannelFactory<NewServiceReference.INewWebService> _channel = new
        //       ChannelFactory<NewServiceReference.INewWebService>(new BasicHttpBinding(), new EndpointAddress("http://localhost:51702/NewWebService.svc"));

        //private readonly INewWebService _service;


        private INewWebService CreateChannel()
        {
            string absolutePath = Path.Combine(AppDomain.CurrentDomain.SetupInformation.PrivateBinPath, "SA.OnlineStore.DataAccess.dll.config");

            Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(
                new ExeConfigurationFileMap { ExeConfigFilename = absolutePath }, ConfigurationUserLevel.None);

            ConfigurationChannelFactory<INewWebService> channelFactory =
                      new ConfigurationChannelFactory<INewWebService>("BasicHttpBinding_INewWebService", configuration, null);

            return channelFactory.CreateChannel();
        }

        //public PublicityRepository()
        //{
        //    _service = _channel.CreateChannel();
        //}

        public PublicityRepository()
        {
          
        }



        public IEnumerable<PublicityModel> GetDefaultList()
        {
            List<PublicityModel> listPublicity = new List<PublicityModel>()
            {
                new PublicityModel()
                 {
                     Id = 100,
                     Name = "Реклама отсутствует",
                     Text = "Нет соединения с сервисом"
                },
                 new PublicityModel()
                 {
                     Id = 101,
                     Name = "Реклама отсутствует",
                     Text = "Нет соединения с сервисом"
                },
                  new PublicityModel()
                 {
                     Id = 102,
                     Name = "Реклама отсутствует",
                     Text = "Нет соединения с сервисом"
                }
            };
            return listPublicity;
        }

        public IEnumerable<PublicityModel> GetPublicityList()
        {
            IEnumerable<PublicityModel> publicityList = ConvertToPublicityWcfList(CreateChannel().GetPublicityList());
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
