﻿namespace SA.OnlineStore.DataAccess.Repositorys
{
    #region Usings
    using SA.OnlineStore.Common.Entity;
    using SA.OnlineStore.Common.Logger;
    using SA.OnlineStore.DataAccess.Implements;
    using SA.OnlineStore.DataAccess.Repositorys;
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.IO;
    using SA.OnlineStore.Common.Convert;
    using System.ServiceModel.Configuration;
    using SA.OnlineStore.DataAccess.ServiceReferenceWCF;
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

           
        private ServiceReferenceWCF.INewWebService CreateChannel()
        {
            string absolutePath = Path.Combine(AppDomain.CurrentDomain.SetupInformation.PrivateBinPath, "SA.OnlineStore.DataAccess.dll.config");

            Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(
                new ExeConfigurationFileMap { ExeConfigFilename = absolutePath }, ConfigurationUserLevel.None);

            ConfigurationChannelFactory<ServiceReferenceWCF.INewWebService> channelFactory =
                      new ConfigurationChannelFactory<ServiceReferenceWCF.INewWebService>("BasicHttpBinding_INewWebService", configuration, null);

            return channelFactory.CreateChannel();
        }

        public IReadOnlyCollection<Publicity> GetAll()
        {
            try
            {
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