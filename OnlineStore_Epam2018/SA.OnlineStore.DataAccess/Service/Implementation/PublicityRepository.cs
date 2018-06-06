namespace SA.OnlineStore.DataAccess.Components
{
    #region Usings
    using SA.OnlineStore.Common.Entity;
    using SA.OnlineStore.Common.Logger;
    using SA.OnlineStore.DataAccess.Implements;
    using SA.OnlineStore.DataAccess.Service;
    using SA.OnlineStore.WCF;
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.IO;
    using System.ServiceModel;
    using SA.OnlineStore.Common.Convert;
    using System.ServiceModel.Configuration;
    using System.Web.UI;
    #endregion

    public class PublicityRepository : IRepository<Publicity>
    {
        private readonly CommonLogger _commonLogger;
        private readonly IRealizationImplementation _realization;

        public PublicityRepository(CommonLogger commonLogger,  IRealizationImplementation realization)
        {
            _commonLogger = commonLogger;
            _realization = realization;
        }

        //private ChannelFactory<INewWebService> _channel = new
        //       ChannelFactory<INewWebService>(new BasicHttpBinding(), new EndpointAddress("http://localhost:51702/NewWebService.svc"));

        //private readonly INewWebService _service;

        private NewServiceReference.INewWebService _service;

        private NewServiceReference.INewWebService CreateChannel()
        {
            string absolutePath = Path.Combine(AppDomain.CurrentDomain.SetupInformation.PrivateBinPath, "app.config");

            Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(
                new ExeConfigurationFileMap { ExeConfigFilename = absolutePath }, ConfigurationUserLevel.None);

            ConfigurationChannelFactory<NewServiceReference.INewWebService> channelFactory =
                      new ConfigurationChannelFactory<NewServiceReference.INewWebService>("BasicHttpBinding_INewWebService", configuration, null);

            return channelFactory.CreateChannel();
        }



        public IReadOnlyCollection<Publicity> GetAll()
        {
            try
            {
                //INewWebService chanel = _channel.CreateChannel();/*CreateChannel();*/
                var chanel = CreateChannel();
                List<Publicity> publicityList = ConvertToPublicityWcfList(chanel.GetPublicityList());
                return publicityList;
            }
            catch (Exception)
            {
                _commonLogger.Info("Problem in PublicityRepository/GetPublicityList");
                throw;
            }
        }

        public List<Publicity> ConvertToPublicityWcfList(IEnumerable<PublicityService> listModel)
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
                Id = model.Id,
                Name = model.Name,
                Text = model.Text,
                Picture = PictureConverter.GetNormalizedImage(model.Picture,60,60)
            };
        }

        public void Create(Publicity item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Publicity item)
        {
            throw new NotImplementedException();
        }

        public Publicity GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}