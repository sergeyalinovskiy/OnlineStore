namespace SA.OnlineStore.DataAccess.Components
{
    using SA.OnlineStore.Common.Convert;
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



        public IReadOnlyCollection<Publicity> GetAll()
        {
            try
            {
                INewWebService chanel = _channel.CreateChannel();/*CreateChannel();*/
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











//namespace SA.OnlineStore.DataAccess.Components
//{
//    using SA.OnlineStore.Common.Const;
//    using SA.OnlineStore.Common.Convert;
//    #region Usings
//    using SA.OnlineStore.Common.Entity;
//    using SA.OnlineStore.Common.Logger;
//    using SA.OnlineStore.DataAccess.Implements;
//    using SA.OnlineStore.DataAccess.Service;
//    using SA.OnlineStore.WCF;
//    using System;
//    using System.Collections.Generic;
//    using System.Configuration;
//    using System.Data.SqlClient;
//    using System.IO;
//    using System.ServiceModel;
//    using System.ServiceModel.Configuration;
//    using System.Web.UI;
//    #endregion

//    public class PublicityRepository : IRepository<Publicity>
//    {
//        private readonly CommonLogger _commonLogger;
//        private readonly IRealizationImplementation _realization;
//        private readonly SqlConnection _connection;

//        public PublicityRepository(CommonLogger commonLogger, SqlConnection connection, IRealizationImplementation realization)
//        {
//            _commonLogger = commonLogger;
//            _realization = realization;
//            _connection = _realization.GetConnection();
//        }

//        private ChannelFactory<INewWebService> _channel = new
//               ChannelFactory<INewWebService>(new BasicHttpBinding(), new EndpointAddress("http://localhost:51702/NewWebService.svc"));

//        //private readonly INewWebService _service;


//        //private INewWebService CreateChannel()
//        //{
//        //    string absolutePath = Path.Combine(AppDomain.CurrentDomain.SetupInformation.PrivateBinPath, "SA.OnlineStore.DataAccess.dll.config");

//        //    Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(
//        //        new ExeConfigurationFileMap { ExeConfigFilename = absolutePath }, ConfigurationUserLevel.None);

//        //    ConfigurationChannelFactory<INewWebService> channelFactory =
//        //              new ConfigurationChannelFactory<INewWebService>("BasicHttpBinding_INewWebService", configuration, null);

//        //    return channelFactory.CreateChannel();
//        //}



//        public IEnumerable<Publicity> GetPublicityList()
//        {
//            try
//            {
//                _connection.Open();
//                var command = _realization.GetCommand(_connection, DbConstant.Command.publi);
//                var basketTable = _realization.CreateTable("publicity");
//                basketTable = _realization.FillInTable(basketTable, command);
//                var list = ParseToBasketList(basketTable);
//                return list;
//            }
//            catch (Exception exeption)
//            {
//                _commonLogger.Info(exeption.Message);
//                throw new Exception();
//            }
//            finally
//            {
//                _connection.Close();
//            }
//        }

//        public IEnumerable<Publicity> ConvertToPublicityWcfList(IEnumerable<PublicityService> listModel)
//        {
//            List<Publicity> resultList = new List<Publicity>();
//            foreach (PublicityService item in listModel)
//            {
//                resultList.Add(ConvertToDataAccessModel(item));
//            }
//            return resultList;
//        }

//        public Publicity ConvertToDataAccessModel(PublicityService model)
//        {
//            return new Publicity
//            {
//                Id = model.Id,
//                Name = model.Name,
//                Text = model.Text,
//                Picture = PictureConverter.GetNormalizedImage(model.Picture, 60, 60)
//            };
//        }

//        public void Create(Publicity item)
//        {
//            throw new NotImplementedException();
//        }

//        public void Delete(int id)
//        {
//            throw new NotImplementedException();
//        }

//        public void Update(Publicity item)
//        {
//            throw new NotImplementedException();
//        }

//        public Publicity GetById(int id)
//        {
//            throw new NotImplementedException();
//        }

//        public IReadOnlyCollection<Publicity> GetAll()
//        {
//            throw new NotImplementedException();
//        }
//    }
//}