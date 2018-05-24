namespace SA.OnlineStore.DataAccess.Components
{
    #region Usings
    using SA.OnlineStore.Common.Entity;
    using SA.OnlineStore.Common.Logger;
    using SA.OnlineStore.DataAccess.Service;
    using SA.OnlineStore.WCF;
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
        private readonly CommonLogger _commonLogger;

        public PublicityRepository(CommonLogger commonLogger)
        {
            _commonLogger = commonLogger;
        }

        private ChannelFactory<INewWebService> _channel = new
               ChannelFactory<INewWebService>(new BasicHttpBinding(), new EndpointAddress("http://localhost:51702/NewWebService.svc"));

        //private readonly INewWebService _service;


        //private INewWebService CreateChannel()
        //{
        //    string absolutePath = Path.Combine(AppDomain.CurrentDomain.SetupInformation.PrivateBinPath, "SA.OnlineStore.DataAccess.dll.config");

        //    Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(
        //        new ExeConfigurationFileMap { ExeConfigFilename = absolutePath }, ConfigurationUserLevel.None);

        //    ConfigurationChannelFactory<INewWebService> channelFactory =
        //              new ConfigurationChannelFactory<INewWebService>("BasicHttpBinding_INewWebService", configuration, null);

        //    return channelFactory.CreateChannel();
        //}

        public IEnumerable<Publicity> GetDefaultList()
        {
            List<Publicity> listPublicity = new List<Publicity>()
            {
                new Publicity()
                 {
                     Id = 100,
                     Name = "Реклама отсутствует",
                     Text = "",
                     Picture="x"
                },
                // new Publicity()
                // {
                //     Id = 101,
                //     Name = "Реклама отсутствует",
                //     Text = "Нет соединения с сервисом",
                //     Picture="x"
                //},
                //  new Publicity()
                // {
                //     Id = 102,
                //     Name = "Реклама отсутствует",
                //     Text = "Нет соединения с сервисом",
                //     Picture="x"
                //}
            };
            return listPublicity;
        }

        public IEnumerable<Publicity> GetPublicityList()
        {
            try
            {
                INewWebService chanel = _channel.CreateChannel();/*CreateChannel();*/
                IEnumerable<Publicity> publicityList = ConvertToPublicityWcfList(chanel.GetPublicityList());
                return publicityList;
            }
            catch (Exception)
            {
                _commonLogger.Info("Problem in PublicityRepository/GetPublicityList");
                throw;
            }
        }

        public IEnumerable<Publicity> ConvertToPublicityWcfList(IEnumerable<PublicityService> listModel)
        {
            List<Publicity> resultList = new List<Publicity>();
            foreach(PublicityService item in listModel)
            {
                resultList.Add(ConvertToDataAccessModel(item));
            }
            return resultList;
        }

        public Publicity ConvertToDataAccessModel(PublicityService model)
        {
            return new Publicity
            {
                Id=model.Id,
                Name = model.Name,
                Text = model.Text,
                Picture=model.Picture
            };
        }
    }
}